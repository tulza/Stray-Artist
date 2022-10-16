using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    float vertical;
    float Speed = 12f;
    float defaultGS = 0;
    bool isLadder;
    bool isClimbing;

    [SerializeField] Rigidbody2D rb;

    void Start() {
        //Find the current gravity scale of the player
        defaultGS = rb.gravityScale;
    }
    
    // Update is called once per frame
    void Update(){
        vertical = Input.GetAxis("Vertical");

        //put player on climbing mode if is on a ladder and is pressing up or down
        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    void FixedUpdate() {
        //set gravity player to have no gravity and allow for vertical input (up/down (w/s))
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * Speed);
        }

        //If not on a ladder set the gravity to default of the character
        else
        {
            rb.gravityScale = defaultGS;
        }
    }

    //Find if player get on a ladder
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder = true;
        }
    }

    //Find if player exit the ladder
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
