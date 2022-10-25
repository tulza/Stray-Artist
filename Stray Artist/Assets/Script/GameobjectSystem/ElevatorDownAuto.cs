using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDownAuto : MonoBehaviour
{
    Rigidbody2D rb;
    
    bool IsOnLevitator = false;
    float MaxHeight;
    float AccelerationUp = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        MaxHeight = rb.position.y;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsOnLevitator == false && rb.position.y < MaxHeight){
        rb.AddForce(new Vector2(0,AccelerationUp), ForceMode2D.Impulse);
        }

        if(IsOnLevitator == false && rb.position.y >= MaxHeight)
        {
            rb.velocity = Vector3.zero;
            rb.position = new Vector2(rb.position.x,MaxHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = false;
        }
    }
}
