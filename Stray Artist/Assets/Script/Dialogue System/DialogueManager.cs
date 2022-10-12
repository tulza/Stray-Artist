using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //Canvas
    public GameObject DialogueUI;
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;
    public TextMeshProUGUI  ButtonText;
    //Npc Dialogue
    private Queue<string> sentences;

    //Use this for initializtion
    void Start(){
        sentences = new Queue<string>();
    }

    void Update() {
        DisplayUI();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Update UI
        nameText.text = dialogue.name;
        ButtonText.text = "[E] Continue >>";

        //Clear previous queue if still exist
        sentences.Clear();
        
        //Add dialogue to queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); //Start of dialogue
    }

    public void DisplayNextSentence()
    {
        //end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //queue next line of dialogue and update canvas
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        //UI to tell player it is last line of npc dialogue
        if (sentences.Count == 0)
        {
            ButtonText.text = "[E] Close";
        }
        
    }
    
    public void EndDialogue()
    {
        Debug.Log ("End of log");
        DialogueTrigger.IsInConversation = false;
    }

    //Check if UI dialogue should display    
    public void DisplayUI()
    {
        if(DialogueTrigger.IsInConversation == true)
        {
            DialogueUI.SetActive(true);
        }
        else
        {
            DialogueUI.SetActive(false);
        }
    }
}
