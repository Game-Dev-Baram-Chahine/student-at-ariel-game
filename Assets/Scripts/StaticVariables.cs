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
    public static int currentGameIndex = 0;
    public static string playerAge = "30";
    public static string playerDegree = "pilot";
    public static float acadimicScore = 0;
    public static float socialScore = 0;
    public static float passAcademic = 80;
    public static float passSocial = 30;
    public static float maxScore = 100;
    public static int tutorialIndex = 0;
    public static string lastScene = "Main Scene";
    public enum Week { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    public static Week day = Week.Sunday;

    public static string[] academicMiniGameByDay = new string[] { "AirPlane-StartScreen", "DefenderIntor", "Bereshit-StartScreen", "Galactic-StartScreen" };
    public static string[] socialMiniGameList = new string[] { "PapertossIntor" };
    /// <summary>
    /// Adds a day and load the appropriate scene. If the player won then load the winning scene, else load the main scene.
    /// </summary>
    public static void AddDay()
    {
        AddDayWithoutLoading();
        if (wonTheGame())
        {
            LoadSceneByName("AcademyDone");
        }
        else
            LoadSceneByName(mainScene);
    }
    public static void initializeScoreboard()
    {
        acadimicScore = 0;
        socialScore = 0;
    }
    /// <summary>
    /// Adds a day to the enum value.
    /// </summary>
    public static void AddDayWithoutLoading()
    {
        int index = (int)day;
        day = (Week)(index + 1);

    }
    /// <summary>
    ///  Adds academic score to the scoreboard.
    /// </summary>
    public static void AddAcademicScore()
    {
        StaticVariables.acadimicScore += StaticVariables.miniGameAcadimicScore;
        checkScore();
        AddDay();
    }
    /// <summary>
    ///  Adds social score to the scoreboard.
    /// </summary>
    public static void AddSocialScore()
    {
        StaticVariables.socialScore += StaticVariables.miniGameSocialScore;
        checkScore();
        AddDay();
    }
    /// <summary>
    /// Adds both social and academic scores to the scoreboard.
    /// </summary>
    /// <param name="points">The points to add to both.</param>
    public static void AddBothSocialAndAcademic(float points)
    {
        StaticVariables.socialScore += points;
        StaticVariables.acadimicScore += points;
        checkScore();
        AddDay();
    }
    ///  <summary>
    /// Returns the scene name by the day and activity.
    /// </summary>
    /// <param name="activityType">The activity</param>
    /// <returns>string: The scene name</returns>
    public static string GetSceneNameByDay(int activityType)
    {
        string[] temp = academicMiniGameByDay;
        if (activityType == 1)
        {
            temp = socialMiniGameList;
            return socialMiniGameList[0];
        }
        string sceneName;
        if (currentGameIndex >= temp.Length)
        {
            currentGameIndex = 0;
        }
        sceneName = temp[currentGameIndex];
        currentGameIndex++;
        return sceneName;
    }
    /// <summary>
    /// Loads a scene by name.
    /// </summary>
    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    /// <summary>
    /// Check if the player won the game by the score.
    /// </summary>
    /// <returns>Boolean: True if the player won the game</returns>
    public static bool wonTheGame()
    {
        return (acadimicScore >= passAcademic && socialScore >= passSocial);
    }
    /// <summary>
    /// Check if the score is at maximum.
    /// </summary>
    public static void checkScore()
    {
        if (StaticVariables.socialScore > maxScore)
        {
            StaticVariables.socialScore = maxScore;
        }
        if (StaticVariables.acadimicScore > maxScore)
        {
            StaticVariables.acadimicScore = maxScore;
        }
    }
}
