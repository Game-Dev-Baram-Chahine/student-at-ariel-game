using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// This class represents the SceneManager of the game
public class SceneSelector : MonoBehaviour
{
    // This function is responsible for loading the scene by index.
    public void SceneSelection(int index){
          SceneManager.LoadScene(index);
    }
}
