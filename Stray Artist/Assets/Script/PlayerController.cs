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

    void OnCollisionEnter(Collision other) {
        
    }
    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }

    bool IsGrounded()
    {
        Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + .01);
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
        float hs = x * speed * run * Time.deltaTime;
        //Move Player
        _t.position += new Vector3(hs, 0, 0);
        //flip player to moving direction
        if (x < 0) {_t.localScale = new Vector3(2,2,1); }
        else if (x > 0){_t.localScale = new Vector3(-2,2,1); }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }

}
