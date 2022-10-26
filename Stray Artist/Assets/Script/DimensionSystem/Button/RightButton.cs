using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    bool isOnButton = false;
    void Update()
    {
        //change stage to the Right of the machine
        if(Input.GetKeyDown(KeyCode.E) && isOnButton == true)
        {
            FindObjectOfType<PortalManager>().ChangeStageRight();
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
