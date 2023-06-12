using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text map;
    public Text instruction;
    public Text playerName;
    public Text playerSocialScore;
    public Text playerAcadimicScore;
    public Text dayText;

    // Update is called once per frame
    void Start()
    {
        if (playerName != null)
        {
            playerName.text = playerName.text + StaticVariables.playerName;
        }
        if (playerSocialScore != null)
        {
            playerSocialScore.text = playerSocialScore.text + StaticVariables.socialScore;
        }
        if (playerAcadimicScore != null)
        {
            playerAcadimicScore.text = playerAcadimicScore.text + StaticVariables.acadimicScore;
        }
        if (dayText != null)
        {
            dayText.text = dayText.text + StaticVariables.day.ToString();
        }
        if (instruction != null)
        {
            instruction.text = "Use: Arrows To Move \n Space To Jump \n E To Enter";
        }
        if (map != null)
        {
            map.text = "Map:\n\n Home ---- Library ---- Faculty";
        }
    }
}
