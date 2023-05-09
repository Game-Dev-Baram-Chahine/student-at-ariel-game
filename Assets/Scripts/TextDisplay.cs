using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text playerName;
    // Update is called once per frame
    void Start()
    {
       playerName.text = playerName.text + " " + StaticVariables.playerName;
    }
}
