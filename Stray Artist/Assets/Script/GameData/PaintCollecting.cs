using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollecting : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D Paint) {

        //only active to game object with tag paint 
        if(Paint.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void UnloadPaintFromSave()
    {

    }
}
