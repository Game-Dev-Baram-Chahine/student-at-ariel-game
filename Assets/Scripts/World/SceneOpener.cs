using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneOpener : MonoBehaviour
{
    private bool playerCollision;
    public Text activityName;
    public Transform objectPos;
    public string activityNameText = "Learn Alone";
    public float ObjectWidth;
    public float ObjectHeight;
    public int activity = 0;

    public LayerMask whatIsPlayer;

    private void Update()
    {
        playerCollision = Physics2D.OverlapBox(objectPos.position, new Vector2(ObjectWidth, ObjectHeight), 0, whatIsPlayer);

        if (playerCollision == true)
        {
            activityName.text = activityNameText;
            activityName.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(StaticVariables.GetSceneNameByDay(activity));
            }
        }
    }
}