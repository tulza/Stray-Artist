using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    public GameObject ObjectToDestroy;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Destroy(ObjectToDestroy);
        }
    }
}
