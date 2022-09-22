using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollecting : MonoBehaviour
{
    public static List<string> PaintsCollected = new List<string>();
    private void OnTriggerEnter2D(Collider2D other) {

        //only active to game object with tag paint 
        if(other.gameObject.tag == "Paint")
        {
            //If came in contact with the paint set active false and set as collected
            (other.gameObject).SetActive(false);
            PaintsCollected.Add(other.gameObject.name);
            //testing
            Debug.Log($"collected {other.gameObject.name}");
        }
    }
}
