using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndGame : MonoBehaviour
{
    //to fade in transition screen
    public GameObject FadeSceneChangePrefab;
    public CanvasGroup InstantiatedFadeScreen;

    public Dialogue dialogue;
    public static bool IsInConversation = false;
    
    //scene management
    public Vector3 LoadToPosition;
    public string sceneToLoad;
    
    bool HasMetCondition = false;
    bool IsChanging = false;

     //Triggers the dialogue
    public void TriggerDialogue()
    {
        //feed npc name and dialogue to manager script and play it to the player
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

     //Get canvasgroup of the Instantiated gameobject
    void Awake() {
        InstantiatedFadeScreen = Instantiate(FadeSceneChangePrefab).GetComponent<CanvasGroup>();
        InstantiatedFadeScreen.alpha = 0;

        dialogue.sentences[0] += $" ( {PaintManager.CollectedPaint.Count} / 6 ) paints";
        MetCodition();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Play next line of dialogue.
            if (IsInConversation == true)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }

        //If in trigger, change the scene to the area of (sceneToLoad)
        if(IsChanging == true)
        {
            //fade in rate
            InstantiatedFadeScreen.alpha += Time.deltaTime*5;
        }
        //Only if scene has fully faded
        if(InstantiatedFadeScreen.alpha >= 1)
        {
            RelocatePlayer.repositionPlayer(LoadToPosition);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    //If hit the collision play the dialogue/0
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && HasMetCondition == true)
        {
            IsChanging = true;
        }
        
        else if(other.tag == "Player")
        {
            TriggerDialogue();
            IsInConversation = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        //Restart dialogue if player moves away from npc
        if(other.tag == "Player")
        {
            IsInConversation = false;
        }
    }

    void MetCodition(){
        if(PaintManager.CollectedPaint.Count >= 6){
            HasMetCondition = true;
        }
    }
}
