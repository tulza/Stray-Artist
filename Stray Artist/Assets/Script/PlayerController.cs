using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physic var
    Rigidbody2D rb;
     Transform _t;
    public GameObject GroundRay;
    public Animator animator;

    public float PlayerScaleX;

    //Movement Var
    [SerializeField] public float speed = 3f;
    [SerializeField] public float RunMutiplier = 1.5f;
    [SerializeField] public float Jumpforce = 20f;
    
    //Condition
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start() {
        isGrounded = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        _t = transform;

        //Get player's localscale in x axis for later flipping
        PlayerScaleX = _t.localScale.x;
    }
    
    void Update()
    {
        Jump();
    }
    
    // FixedUpdate is called 50 times a second
    void FixedUpdate()
    {
        //Check input every 50 frame
        move();
        
        Vector2 Down = -Vector2.up;
        //Cast a ray straight down
        
        RaycastHit2D OnGround = Physics2D.Raycast (GroundRay.transform.position, Down);

        Debug.DrawRay (GroundRay.transform.position, Down * OnGround.distance, Color.red);
        //If it hits something with collider
        if(OnGround.collider != null)
        {
            if(OnGround.distance <= 0.05f){
                animator.SetBool("IsGrounded", true);
                isGrounded = true;
            }
            else{
                animator.SetBool("IsGrounded", false);
                isGrounded = false;
            }

            
        }
    }


    void move()
    {
        //Get Input
         float x =  Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));

        //is Running
        float run = 1f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = RunMutiplier;
        }

        //horizontal speed calculation
        float hs = x * speed * run * Time.deltaTime * 200;
        //Move Player
        rb.velocity = new Vector2(hs,rb.velocity.y);

        //flip player to moving direction via
        if (x < 0) { _t.localScale = new Vector3(-PlayerScaleX, _t.localScale.y,1); }
        else if (x > 0){ _t.localScale = new Vector3(PlayerScaleX, _t.localScale.y,1); }
    }

    void Jump()
    {
        //Check if player is grounded when jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true && PlayerMenuControl.GameIsPause == false )
        {
            //Add force to the y axis to do a jump action
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);

            animator.SetBool("IsGrounded", false);
        }
    }
}
