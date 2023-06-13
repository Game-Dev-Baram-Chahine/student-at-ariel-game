using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    public GameObject tutorialGameObject;
    public Text tutorialText;
    private string[] tutorial;
    private void Start()
    {
        if (StaticVariables.day == StaticVariables.Week.Sunday)
        {
            tutorialGameObject.SetActive(true);
            tutorial = new string[] { "Welcome to the game, this tutorial will show you how to navigate. Press on the C key to continue the tutorial."
        , "To navigate use the arrow. Try it please and then press on the C key to continue the tutorial.", "To enter a building, got to the desired building. You have three options Home, Library, or Faculty. Go there and press E to enter"};
            tutorialText.text = tutorial[StaticVariables.tutorialIndex];
        }
        else
        {
            tutorialGameObject.SetActive(false);
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("A key or mouse click has been detected");
            StaticVariables.tutorialIndex++;
            if (StaticVariables.tutorialIndex < tutorial.Length)
            {
                tutorialText.text = tutorial[StaticVariables.tutorialIndex];
            }
            else
            {
                tutorialGameObject.SetActive(false);
            }
        }
    }
}
