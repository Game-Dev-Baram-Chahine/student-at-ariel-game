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
        StartCoroutine(LoadAsynchronousLoad(scene));
    }
    // This method is mae from this video tutorial: https://www.youtube.com/watch?v=YMj2qPq9CP8&ab_channel=Brackeys
    IEnumerator LoadAsynchronousLoad(string scene)
    {
        yield return null;
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;
        loadingSlider.SetActive(true);
        while (!ao.isDone)
        {
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            // Loading completed
            slider.value = progress;
            if (ao.progress == 0.9f)
            {
                activityName.text = learningWithFriendsMessage;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StaticVariables.AddBothSocialAndAcademic(10);
                    ao.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}