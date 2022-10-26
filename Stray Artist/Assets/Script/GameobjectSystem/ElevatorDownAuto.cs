using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDownAuto : MonoBehaviour
{
    //script for a platform that falls when the player is standing on it.

    Rigidbody2D rb;
    
    bool IsOnLevitator = false;
    float MaxHeight;
    float AccelerationUp = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody and max height of the platform
        rb = gameObject.GetComponent<Rigidbody2D>();
        MaxHeight = rb.position.y;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //If the player is not on the platform move the platform up
        if(IsOnLevitator == false && rb.position.y < MaxHeight){
        rb.AddForce(new Vector2(0,AccelerationUp), ForceMode2D.Impulse);
        }

        //else fall with the player
        if(IsOnLevitator == false && rb.position.y >= MaxHeight)
        {
            rb.velocity = Vector3.zero;
            rb.position = new Vector2(rb.position.x,MaxHeight);
        }
    }

    //enable levitation
    private void OnTriggerEnter2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = true;
        }
    }

    //disable levitation
    private void OnTriggerExit2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = false;
        }
    }
}
