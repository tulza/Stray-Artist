using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
	BoxCollider2D bc;
    [SerializeField] float speed = 5f;
    [SerializeField] float RunMutiplier = 1.75f;

    public Transform _t;
    
    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        _t = transform;
        //Get Input
        float x =  Input.GetAxisRaw("Horizontal");
        float y =  Input.GetAxisRaw("Vertical");

        //is Running
        float run = 1f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
        run = RunMutiplier;
        }
        //Vertical and horizontal speed calculation
        float vs = x * speed * run * Time.deltaTime;
        float hs = y * speed * run * Time.deltaTime;
        //Move Player
        _t.position += new Vector3(vs, hs, 0);
        //flip player to moving direction
        if (x < 0) {_t.localScale = new Vector3(3,3,1); }
        else if (x > 0){_t.localScale = new Vector3(-3,3,1); }
    }
}
