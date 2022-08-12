using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{
    int a = 0;
    public Transform _t;
    public bool IsInTrigger = false;
    public bool IsHolding = false;
    public string message = "smt";

    private void OnTriggerStay2D(Collider2D other) {
        
        showGui = true;
        if(Input.GetKey(KeyCode.Z)){
            if(other.CompareTag("Throwable") && IsHolding == false ){
                a++;
                Debug.Log("Z Key pressed ");
                other.transform.position = new Vector3(0,1,0);
                IsHolding = true;
                //For picking up object, when picked up Isholding object is true
            } 
        }
       
    }
    /*
        ! Fix NOWWW hsihdioahodhhji9sfjiodfiio
        !this is absolutely garbage please fix it right now or i will cry 
        * TODO: fasjfopjajsop
        ? help  saopfjaosfjpoajsfpeerjiowjioefjioefjkoefjkofjkfjsopjfdosdfjopsfopdfopdfopdpdpdssfosdopdfsdfkopsfkopsfoksksdpf-djf0-sdjfjf-f-wjfowns0nnfsnfsdf
    */ 

    void OnGUI()
    {
        if(showGui)
        GUI.Box(new Rect(0,0,10,10),"Press E to pick " + message);
    }


    // Update is called once per frame
    void Update()
    {
        if(showGui && Input.GetKeyDown(KeyCode.E))
        {
            //Do some stuffs like health
            Destroy(gameObject); //Remove the item
        }
    }

}
