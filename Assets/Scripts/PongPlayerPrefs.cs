using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PongPlayerPrefs
{
    internal static void SaveBestScore(int newBestScore)
    {
        PlayerPrefs.SetInt("BestScore", newBestScore);
    }
    internal static int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }
    internal static void SaveColor(Color color, string key)
    {
        PlayerPrefs.SetFloat(key + "R", color.r);
        PlayerPrefs.SetFloat(key + "G", color.g);
        PlayerPrefs.SetFloat(key + "B", color.b);
    }

    internal static Color GetColor(string key)
    {
        float R = PlayerPrefs.GetFloat(key + "R");
        float G = PlayerPrefs.GetFloat(key + "G");
        float B = PlayerPrefs.GetFloat(key + "B");
        var color = new Color(R, G, B, 1);
        if (color == Color.black)
            color = Color.white;
        return color;
    }
}
