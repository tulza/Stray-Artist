using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //name and dialogue of NPC
    public Dialogue dialogue;
    //Conditions
    public bool CanTalk = false;
    public static bool IsInConversation = false;

    //Triggers the dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.E) && CanTalk == true )
        {
            if (IsInConversation == false)
            {
                IsInConversation = true;
                TriggerDialogue();
            }

            else
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
          CanTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            CanTalk = false;
            IsInConversation = false;
        }
    }
}
