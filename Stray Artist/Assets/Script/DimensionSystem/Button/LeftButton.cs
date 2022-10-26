using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    bool isOnButton = false;
    void Update()
    {
        //If on the button
        if(Input.GetKeyDown(KeyCode.E) && isOnButton == true)
        {
            FindObjectOfType<PortalManager>().ChangeStageLeft();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            isOnButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            isOnButton = false;
        }
    }
}