using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscLogic : MonoBehaviour
{
    public string sceneName = "Main Scene";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
