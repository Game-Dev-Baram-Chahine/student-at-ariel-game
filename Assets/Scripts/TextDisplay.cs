using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text playerName;
    public Text playerSocialScore;
    public Text playerAcadimicScore;

    // Update is called once per frame
    void Start()
    {
        if (playerName != null)
        {
            playerName.text = playerName.text + " " + StaticVariables.playerName;
        }
        if (playerSocialScore != null)
        {
            playerSocialScore.text = playerSocialScore.text + " " + StaticVariables.socialScore;
        }
        if (playerAcadimicScore != null)
        {
            playerAcadimicScore.text = playerAcadimicScore.text + " " + StaticVariables.acadimicScore;
        }
    }
}
