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
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update() {
        DisplayUI();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log ("Starting dialogue with " + dialogue.name );
        nameText.text = dialogue.name;
        ButtonText.text = "[E] Continue >>";

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

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
