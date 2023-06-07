using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    private bool playerCollision;
    public Transform objectPos;
    public float ObjectWidth;
    public float ObjectHeight;

    public LayerMask whatIsPlayer;

    private void Update()
    {
        playerCollision = Physics2D.OverlapBox(objectPos.position, new Vector2(ObjectWidth, ObjectHeight), 0, whatIsPlayer);

        if (playerCollision == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(StaticVariables.GetSceneNameByDay());
            }
        }
    }
}