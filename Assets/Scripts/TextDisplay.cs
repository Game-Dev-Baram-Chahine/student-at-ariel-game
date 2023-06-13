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

    public string whatToDoText = "Tip:\n Level Up Your Academic & Social Score \n Learn & Socialize In The Faculty & Library";

    public string successSpeechText = "Your determination and hard work as a student in this game have paid off. \nYou've shown incredible skill, resilience, and a thirst for knowledge. \nThis achievement is just the beginning of your journey to even greater heights. \nKeep striving for excellence, and the world will be yours to conquer.";
    public string failSpeechText = "Even though you didn't achieve the desired outcome in this game as a student, I want to applaud your dedication and effort. \nRemember that setbacks are stepping stones to success, and with perseverance, you'll overcome any obstacles that come your way. \nKeep your head up and continue to strive for greatness.";
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
            whatToDo.text = whatToDoText;
        }
        if (congrats != null)
        {
            if (StaticVariables.wonTheGame())
            {
                congrats.text = "Congratulations";
            }
            else
            {
                congrats.text = "Keep Going";
            }
        }
        if (speechText != null)
        {
            if (StaticVariables.wonTheGame())
            {
                speechText.text = successSpeechText;
            }
            else
            {
                speechText.text = failSpeechText;
            }
        }

    }
}
