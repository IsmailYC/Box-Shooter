using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager{
    public const string HIGHSCORE_KEY = "Highscore";
    public const string AUDIO_KEY = "Audio";

    public static int GetHighscore()
    {
        if (PlayerPrefs.HasKey(HIGHSCORE_KEY))
            return PlayerPrefs.GetInt(HIGHSCORE_KEY);
        else
            return 0;
    }

    public static bool GetAudio()
    {
        if (PlayerPrefs.HasKey(AUDIO_KEY))
            return PlayerPrefs.GetInt(AUDIO_KEY) == 1;
        else
            return true;
    }

    public static bool SetHighscore(int score)
    {
        if (score > GetHighscore())
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
            return true;
        }
        else
            return false;
    }

    public static void SetAudio(bool audio)
    {
        if (audio)
            PlayerPrefs.SetInt(AUDIO_KEY, 1);
        else
            PlayerPrefs.SetInt(AUDIO_KEY, 0);
    }
}
