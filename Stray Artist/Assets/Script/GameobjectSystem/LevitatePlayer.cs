using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatePlayer : MonoBehaviour
{
    bool IsOnLevitator = false;
    float LevitationStrength = 1f;
    public Rigidbody2D PlayerRb;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsOnLevitator == true){
        PlayerRb.AddForce(new Vector2(0, LevitationStrength), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Player) {
        if(Player.tag == "Player")
        {
            IsOnLevitator = false;
        }
    }
}
