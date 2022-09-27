using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physic var
    Rigidbody2D rb;
    public Transform _t;

    public float PlayerScaleX;

    //Movement Var
    [SerializeField] public float speed = 3f;
    [SerializeField] public float RunMutiplier = 1.5f;
    [SerializeField] public float Jumpforce = 15f;
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start() {
        isGrounded = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        _t = transform;

        //Get player's localscale in x axis for later flipping
        PlayerScaleX = _t.localScale.x;
    }
    
    void Update()
    {
        Jump();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Check input every frame
        move();
    }

    void move()
    {
        //Get Input
        float x =  Input.GetAxisRaw("Horizontal");

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
        if (x < 0) { _t.localScale = new Vector3(PlayerScaleX, _t.localScale.y,1); }
        else if (x > 0){ _t.localScale = new Vector3(-PlayerScaleX, _t.localScale.y,1); }
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
