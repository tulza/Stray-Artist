using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] float speed = 8f;
    [SerializeField] float RunMutiplier = 1.5f;

    [SerializeField] float Jumpforce = 15f;

    public Transform _t;
    bool isGrounded;
    // N
    void Start() {
        isGrounded = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check input every frame
        move();
        Jump();
    }

    void move()
    {
        _t = transform;
        //Get Input
        float x =  Input.GetAxisRaw("Horizontal"); //? Move
        
        //is Running
        float run = 1f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
        run = RunMutiplier;
        }

        //horizontal speed calculation
        float hs = x * speed * run;

        //Move Player
        rb.velocity = new Vector2(hs,rb.velocity.y);

        //flip player to moving direction
        if (x < 0) {_t.localScale = new Vector3(2,2,1); }
        else if (x > 0){_t.localScale = new Vector3(-2,2,1); }
    }

    void Jump()
    {
        //Check if player is grounded when jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true )
        {
            //Add force to the y axis to do a jump action
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
        }
    }

    
    void OnCollisionEnter2D(Collision2D other) {
        //On collision with the ground => enable jump
        if (other.gameObject.tag == "Ground" && isGrounded == false)
         {
             isGrounded = true;
         }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        //exiting the collision with the ground => disable jump
        if (other.gameObject.tag == "Ground")
         {
             isGrounded = false;
         }
    }
}
