using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    public InputField playerName;
    public InputField playerAge;

    public void Update()
    {
        StaticVariables.playerName = playerName.text;
        StaticVariables.playerAge = playerAge.text;

    }
    // This method is for modifying the static value of degree
    public void SelectDegree(string degree)
    {
        StaticVariables.playerDegree = degree;
    }
    // This method is for Loading a scene by the scene name
    public void SceneSelectByDegree(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
