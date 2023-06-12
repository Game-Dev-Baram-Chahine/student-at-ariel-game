using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GalacticLangSpellcheck : MonoBehaviour
{
    [SerializeField] public string nextLevelTag;  // next level name to go to
    [SerializeField] public InputField inputField;
    [SerializeField] public string correctAnswer;

    [SerializeField] public Text messageText;
    [SerializeField] public string incorrectAnswerMessage = "Incorrect answer!";
    [SerializeField] public float messageDisplayTime = 2f;
    private float messageTimer = 0f;
    private bool displayMessage = false;

    public void CheckAnswer()
    {
        string userInput = inputField.text;
        string userInputLowercase = userInput.ToLower();
        if (userInputLowercase.Equals(correctAnswer))
        {
            Debug.Log("Correct answer!");
            StaticVariables.LoadSceneByName(nextLevelTag);
        }
        else
        {
            Debug.Log("Incorrect answer!");
            messageText.text = incorrectAnswerMessage;
            messageTimer = 0f;
            displayMessage = true;
        }
    }

    void Update()
    {
        if (displayMessage)
        {
            messageTimer += Time.deltaTime;
            if (messageTimer >= messageDisplayTime)
            {
                displayMessage = false;
                messageText.text = "";
            }
        }
    }
}
