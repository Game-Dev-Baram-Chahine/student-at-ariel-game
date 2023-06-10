using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuGeneric : MonoBehaviour
{

    public void Won(int activityType)
    {
        if (activityType == 0)
        {
            StaticVariables.AddAcademicScore();
            return;
        }
        StaticVariables.AddSocialScore();
    }
}
