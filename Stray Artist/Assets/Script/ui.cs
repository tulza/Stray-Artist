using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public static ui instance;
    public int score = 0;

    private void Awake() {
        instance = this;
    }

    public void scores()
    {
        Debug.Log(score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
