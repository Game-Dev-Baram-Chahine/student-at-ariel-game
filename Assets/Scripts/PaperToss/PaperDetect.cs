using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDetect : MonoBehaviour
{
    [SerializeField] public string paperTag = "Player";  // Tag of the enemy objects
    [SerializeField] public string nextLevelTag;  // next level name to go to

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.CompareTag(paperTag))
        {
            Debug.Log("trigger paper");
            // Handle the collision with the enemy
            Invoke("LoadSceneDelayed", 1.5f);
        }
    }
    private void LoadSceneDelayed()
    {
        StaticVariables.LoadSceneByName(nextLevelTag);
    }
}
