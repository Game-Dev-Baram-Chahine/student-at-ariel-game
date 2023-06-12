using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class StaticVariables : MonoBehaviour
{
    public static readonly float miniGameAcadimicScore = 25;
    public static readonly float miniGameSocialScore = 20;
    public static readonly string mainScene = "Main Scene";
    public static string playerName = "John Doe";
    public static string playerAge = "30";
    public static string playerDegree = "pilot";
    public static float acadimicScore = 0;
    public static float socialScore = 0;
    public static float passAcademic = 80;
    public static float passSocial = 40;
    public enum Week { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    public static Week day = Week.Sunday;

    public static string[] academicMiniGameByDay = new string[] { "AirPlane-StartScreen", "DefenderIntor", "Bereshit-StartScreen", "Galactic-StartScreen" };
    public static string[] socialMiniGameList = new string[] { "PapertossIntor" };

    public static void AddDay()
    {
        AddDayWithoutLoading();
        LoadSceneByName(mainScene);
    }
    public static void AddDayWithoutLoading()
    {
        int index = (int)day;
        day = (Week)(index + 1);
        if (day == Week.Saturday)
        {
            LoadSceneByName("AcademyDone");
        }
    }
    public static void AddAcademicScore()
    {
        StaticVariables.acadimicScore += StaticVariables.miniGameAcadimicScore;
        AddDay();
    }
    public static void AddSocialScore()
    {
        StaticVariables.socialScore += StaticVariables.miniGameSocialScore;
        AddDay();
    }
    public static void AddBothSocialAndAcademic(float points)
    {
        StaticVariables.socialScore += points;
        StaticVariables.acadimicScore += points;
        AddDay();
    }
    public static string GetSceneNameByDay(int activityType)
    {
        string[] temp = academicMiniGameByDay;
        if (activityType == 2)
        {

        }
        if (activityType == 1)
        {
            temp = socialMiniGameList;
            return socialMiniGameList[0];
        }
        int index = (int)day;
        string sceneName;
        if (index >= temp.Length)
        {
            sceneName = temp[1];
        }
        else
        {
            sceneName = temp[index];
        }
        return sceneName;
    }
    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static bool wonTheGame()
    {
        return (acadimicScore > passAcademic && socialScore > passSocial);
    }
}
