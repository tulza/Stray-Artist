using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Load escape menu screen as additive instead of replacing
        SceneManager.LoadScene("Escape Menu", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Dialogue UI", LoadSceneMode.Additive);
    }
}
