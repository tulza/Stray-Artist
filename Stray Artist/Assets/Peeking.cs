using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Peeking : MonoBehaviour
{
    public Transform ObjectToFollow;
    CinemachineVirtualCamera Vcam;
    GameObject Player;
    bool IsPeeking = false;
    bool CanPeak = false;
    public float camSize;
    float playerCam;
    // Start is called before the first frame update
    void Start()
    {
        Vcam = GameObject.FindWithTag("Vcam").GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindWithTag("Player");
        playerCam = Vcam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {if(IsPeeking == false && CanPeak){
            playerCam = Vcam.m_Lens.OrthographicSize;
            Vcam.m_Lens.OrthographicSize = camSize;
            IsPeeking = true;
            Vcam.Follow = ObjectToFollow;
            }
        else if(CanPeak){
            IsPeeking = false;
            Vcam.m_Lens.OrthographicSize = playerCam;
            Vcam.Follow = Player.transform;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            CanPeak = true;
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            CanPeak = false;
            if(Vcam.Follow == Player.transform){
            Vcam.m_Lens.OrthographicSize = playerCam;
            Vcam.Follow = Player.transform;
            }
        }
    }
    
}
