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
        defaultGS = rb.gravityScale;
    }
    
    // Update is called once per frame
    void Update(){
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    void FixedUpdate() {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * Speed);
        }

        else
        {
            rb.gravityScale = defaultGS;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
