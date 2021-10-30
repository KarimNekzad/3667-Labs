using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    private const int _menuIndex = 0;
    private const int _settingsIndex = 1;
    private const int _highScoresIndex = 2;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(_menuIndex);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void Settings()
    {
        SceneManager.LoadScene(_settingsIndex);
    }

    public void HighScores()
    {
        SceneManager.LoadScene(_highScoresIndex);
    }
    public void SetDifficultyEasy()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }

    public void SetDifficultyMedium()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
    }

    public void SetDifficultyHard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }
}

// get these diffuculty strings in the enemy scripts such as the movement ai and in the awake method set the diffuculty
// using that method i made but just assign the string as whatever the difficulty is set to. if the value is null, default
// difficulty should be medium.