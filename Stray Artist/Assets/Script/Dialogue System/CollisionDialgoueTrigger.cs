using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDialgoueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool IsInConversation = false;

    //Triggers the dialogue
    public void TriggerDialogue()
    {
        //feed npc name and dialogue to manager script and play it to the player
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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

    }

    //If hit the collision play the dialogue/0
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
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
}
