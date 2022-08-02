using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{
    int c = 0, a = 0;
    public Transform _t;
    
    bool IsInTrigger;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Throwable")){
            c++;
            Debug.Log($"In Trigger {c}x");
            IsInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Throwable"))
        {
            Debug.Log($"Off Trigger {c}x");
            IsInTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(Input.GetKeyDown(KeyCode.Z)){
            if(other.CompareTag("Throwable")){
                a++;
                Debug.Log("Z Key pressed " + a);
                Destroy(other.gameObject);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("e pressed");
        }
    }

    void DisplayKey()
    {
        
    }
}
