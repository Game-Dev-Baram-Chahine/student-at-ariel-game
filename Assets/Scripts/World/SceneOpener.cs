using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneOpener : MonoBehaviour
{
    public GameObject loadingSlider;
    public Slider slider;
    private float pointsForLearning = 10.0f;
    private bool playerCollision;
    public Text activityName;
    public Transform objectPos;
    public string activityNameText = "Learn Alone";
    public float ObjectWidth;
    public float ObjectHeight;
    public int activity = 0;
    public string learningWithFriendsMessage = "Great you learned with your friends, which means that your academic and social score gets increased by 10 each. Press E to go to the main screen.";
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
                if (activity == 2)
                {
                    Debug.Log("Learn with friends");
                    LoadScreen("Main Scene");
                }
                else
                {
                    SceneManager.LoadScene(StaticVariables.GetSceneNameByDay(activity));
                }
            }
        }
        else
        {
            activityName.gameObject.SetActive(false);
        }
    }


    public void LoadScreen(string scene)
    {
        StartCoroutine(LoadProgressBar(scene));
    }
    IEnumerator LoadProgressBar(string scene)
    {
        loadingSlider.SetActive(true);
        float MaxTime = 100f;
        float temp = MaxTime;
        float ActiveTime = 0f;
        while (ActiveTime <= MaxTime && MaxTime > 0)
        {
            temp -= Time.deltaTime;
            ActiveTime = MaxTime - temp;
            var percent = ActiveTime / MaxTime;
            slider.value = Mathf.Lerp(0, 1, percent);
        }
        activityName.text = learningWithFriendsMessage;
        if (Input.GetKeyDown(KeyCode.E))
        {
            StaticVariables.AddBothSocialAndAcademic(10);
            yield return null;
        }
    }
}