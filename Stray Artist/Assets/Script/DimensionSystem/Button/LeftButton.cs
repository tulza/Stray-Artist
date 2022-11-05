using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    //UI
    public GameObject ArrowUIPrefab;
    public CanvasGroup InstanceArrowUIPrefab;
    bool isOnButton = false;

    private void Start() {
        //Instance UI and set alpha to 0
        InstanceArrowUIPrefab= GameObject.Instantiate(ArrowUIPrefab).transform.GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
        InstanceArrowUIPrefab.alpha = 0;
    }

    void Update()
    {
        //change stage to the left of the machine
        if(Input.GetKeyDown(KeyCode.E) && isOnButton == true)
        {
            FindObjectOfType<PortalManager>().ChangeStageLeft();
        }
    ArrowIndicator();
    }

    void ArrowIndicator(){
        //Fade in UI if on arrow
        if(isOnButton){
            InstanceArrowUIPrefab.alpha += 2 * Time.deltaTime;
        }
        //fade out UI
        else if(isOnButton == false){
            InstanceArrowUIPrefab.alpha -= 2 * Time.deltaTime;
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
