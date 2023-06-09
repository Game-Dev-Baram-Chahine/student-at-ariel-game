using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCheckEnemy : MonoBehaviour
{
    [SerializeField] public string nextLevelTag;  // next level name to go to
    void Update()
    {
        // Check if there are no more enemies
        if (AreEnemiesDefeated())
        {
            // Handle the case when all enemies are defeated
            //////////////////////////////////////////////////////////////////////////////////////////////////////NEXTLEVEL
            Debug.Log("no more enemies");
            StaticVariables.LoadSceneByName(nextLevelTag);
        }
    }

    bool AreEnemiesDefeated()
    {
        // Find all game objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If there are no enemies, return true; otherwise, return false
        return enemies.Length == 0;
    }
}
