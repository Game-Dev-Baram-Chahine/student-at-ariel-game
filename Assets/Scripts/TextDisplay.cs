using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text whatToDo;
    public Text map;
    public Text instruction;
    public Text playerName;
    public Text playerSocialScore;
    public Text playerAcadimicScore;
    public Text dayText;
    public Text congrats;
    public Text speechText;
    public string instructionText = "Use: Arrows To Move \n Space To Jump \n E To Enter";
    public string mapText = "Map:\n\n Home ---- Library ---- Faculty";

    // public string whatToDoText = ;

    public string successSpeechText = "Your determination and hard work as a student in this game have paid off. \nYou've shown incredible skill, resilience, and a thirst for knowledge. \nThis achievement is just the beginning of your journey to even greater heights. \nKeep striving for excellence, and the world will be yours to conquer.";
    
    // Update is called once per frame
    void Start()
    {
        if (playerName != null)
        {
            playerName.text = playerName.text + StaticVariables.playerName;
        }
        if (playerSocialScore != null)
        {
            playerSocialScore.text = playerSocialScore.text + StaticVariables.socialScore + "/" + StaticVariables.passSocial;
        }
        if (playerAcadimicScore != null)
        {
            playerAcadimicScore.text = playerAcadimicScore.text + StaticVariables.acadimicScore + "/" + StaticVariables.passAcademic;
        }
        if (dayText != null)
        {
            dayText.text = dayText.text + StaticVariables.day.ToString();
        }
        if (instruction != null)
        {
            instruction.text = instructionText;
        }
        if (map != null)
        {
            map.text = mapText;
        }
        if (whatToDo != null)
        {
            whatToDo.text = "Tip: \n Level Up Your Academic & Social Score \n Learn & Socialize In The Faculty & Library";
        }
        if (congrats != null)
        {
            congrats.text = "Congratulations";
            StaticVariables.initializeScoreboard();
        }
        if (speechText != null)
        {
            speechText.text = successSpeechText;
        }

    }
}
