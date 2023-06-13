using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the scene by the index.
    /// </summary>
    /// <param name="level">The scene index.</param>
    public void StartGame(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void GameOver(int index)
    {
        SceneManager.LoadScene(index);
    }
    /// <summary>
    /// Loads the scene by the scene name represented as a string.
    /// </summary>
    /// <param name="sceneName">The scene name.</param>
    public void Won(string sceneName)
    {
        StaticVariables.AddAcademicScore();
    }
}
