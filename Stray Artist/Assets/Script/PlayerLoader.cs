using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    
    [SerializeField] public GameObject PlayerPrefab;

    public void LoadPlayer(){
        GameObject gameObjInst = (GameObject) GameObject.Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
        //Replace name to just be "Player" (remove the clone bit)
        gameObjInst.name = gameObjInst.name.Replace("(Clone)", "");
    }
}
