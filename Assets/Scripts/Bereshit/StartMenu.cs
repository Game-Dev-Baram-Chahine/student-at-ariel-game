using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void GameOver(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Won(string sceneName)
    {
        StaticVariables.AddAcademicScore();
    }
}
