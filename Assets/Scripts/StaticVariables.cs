using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StaticVariables : MonoBehaviour
{
    public static float miniGameAcadimicScore = 5;
    public static float miniGameSocialScore = 5;
    public static string playerName = "john doe";
    public static string playerAge = "30";
    public static string playerDegree = "pilot";
    public static float acadimicScore = 0;
    public static float socialScore = 0;
    public enum Week { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public static Week day = Week.Monday;

    public static string[] academicMiniGameByDay = new string[] { "Bereshit-StartScreen", "" };

    public static void AddAcademicScore()
    {
        StaticVariables.acadimicScore += StaticVariables.miniGameAcadimicScore;
    }
    public static void AddSocialScore()
    {
        StaticVariables.socialScore += StaticVariables.miniGameSocialScore;
    }

}
