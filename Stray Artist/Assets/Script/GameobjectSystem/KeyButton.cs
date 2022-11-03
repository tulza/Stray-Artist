using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KeyButton : MonoBehaviour
{
    public GameObject PrefabEmpty;
    SpriteRenderer buttonSpriteRenderer;
    GameObject instancedEmpty;

    public GameObject ObjectToDestroy;
    CinemachineVirtualCamera Vcam;

    bool Deleted = false;
    bool Looking = false;
    float timer = 0;

    private void Start() {
        buttonSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vcam = GameObject.FindWithTag("Vcam").GetComponent<CinemachineVirtualCamera>();
        instancedEmpty = Instantiate(PrefabEmpty, ObjectToDestroy.transform.position, Quaternion.identity);
    }

    private void Update() {
        if(Deleted == true && timer < 2f && Looking == false){
            timer += 1 * Time.deltaTime;
            if(timer >= 1.5f){
                Vcam.Follow = GameObject.FindWithTag("Player").transform;
                Looking = true;
            }
        }
    }

    //Destroy a spicific object when player touch the "key object"
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && Deleted == false)
        {
            try{
                Deleted = true;

                //destroy with 2 second delay
                Destroy(ObjectToDestroy,3f);
                //Add rigidbody to add gravity to object
                Rigidbody2D ObjectRigidbody = ObjectToDestroy.AddComponent<Rigidbody2D>();
                //Remove collider and make it jump up a bit
                Destroy(ObjectToDestroy.GetComponent<BoxCollider2D>());

                buttonSpriteRenderer.color = Color.grey;
                Vcam.Follow = instancedEmpty.transform;
                ObjectRigidbody.gravityScale = 1.5f;
                ObjectRigidbody.AddForce(transform.up * 5f, ForceMode2D.Impulse);
                ObjectRigidbody.AddTorque(2f, ForceMode2D.Impulse);
            }
            catch{
                Debug.Log("No object to destroy");
            }
        }

        
    }
}
