using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    float MaxCameraSize = 18;
    float minCameraSize = 10; 

    //Load with default camera size
    void Start() {
        vcam.m_Lens.OrthographicSize = 14;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //increase the camera size 
        if (Input.GetKey(KeyCode.LeftBracket) && vcam.m_Lens.OrthographicSize <= MaxCameraSize)
        {
            vcam.m_Lens.OrthographicSize += 3*Time.deltaTime;
        }

        //decrease the camera size 
        if (Input.GetKey(KeyCode.RightBracket) && vcam.m_Lens.OrthographicSize >= minCameraSize)
        {
            vcam.m_Lens.OrthographicSize -= 3*Time.deltaTime;
        }
    }
}
