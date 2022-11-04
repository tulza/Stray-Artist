using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //name and dialogue of NPC
    public Dialogue dialogue;
    public Transform NpcGameObject;
    public Transform InstantiatedTextBox;
    public GameObject TextBoxPrefab;
    //Conditions
    public bool CanTalk = false;
    public static bool IsInConversation = false;

    //Instance NPC interaction UI
    private void Start() {
        InstantiatedTextBox = Instantiate(TextBoxPrefab, NpcGameObject).transform;
        InstantiatedTextBox.Translate(2,1,0);
    }

    //Triggers the dialogue
    public void TriggerDialogue()
    {
        //feed npc name and dialogue to manager script and play it to the player
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && CanTalk == true )
        {
            //starts dialogue
            if (IsInConversation == false)
            {
                IsInConversation = true;
                TriggerDialogue();
            }

            //play next dialogue if already talking
            else
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Enable player to be able to talk to the npc
        if (other.tag == "Player")
        {
            InstantiatedTextBox.gameObject.SetActive(true);
            CanTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Restart dialogue if player moves away from npc
        if(other.tag == "Player")
        {
            InstantiatedTextBox.gameObject.SetActive(false);
            CanTalk = false;
            IsInConversation = false;
        }
    }
}
