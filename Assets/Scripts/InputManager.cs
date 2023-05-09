using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    public InputField playerName;
    public InputField playerAge;
    
    public void Update(){
        StaticVariables.playerName = playerName.text;
        StaticVariables.playerAge = playerAge.text;
        
    }
    public void SelectDegree(string degree){
        StaticVariables.playerDegree = degree;
    }
}
