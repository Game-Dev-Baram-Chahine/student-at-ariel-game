using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuging : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StaticVariables.playerName);
        Debug.Log(StaticVariables.playerAge);
        Debug.Log(StaticVariables.playerDegree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
