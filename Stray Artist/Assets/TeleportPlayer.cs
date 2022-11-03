using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    GameObject Player;
    public GameObject PlaceToTeleportTo;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Player.transform.position = PlaceToTeleportTo.transform.position;
    }
}
