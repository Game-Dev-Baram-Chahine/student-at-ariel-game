using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static string playerName = "jhon deo";
    public static string playerAge = "30";
    public static string playerDegree = "pilot";
    public static float acadimicScore = 0;
    public static float socialScore = 0;
    public enum Week { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public static Week day = Week.Monday;

}
