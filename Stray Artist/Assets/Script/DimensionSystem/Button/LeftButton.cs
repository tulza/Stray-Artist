using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    bool isOnButton = false;
    void Update()
    {
        //change stage to the left of the machine
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
