using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField] private Text[] _highScoreNames = new Text[5];
    [SerializeField] private Text[] _highScoreValues = new Text[5];

    private const int _numHighScores = 5;
    private const string _highScoreNameKey = "HighScoreName";
    private const string _highScoreValueKey = "HighScoreValue";

    // Start is called before the first frame update
    void Start()
    {
        string currentPlayerName = PlayerPrefs.GetString("Name");
        int currentPlayerScore = PlayerPrefs.GetInt("Score");

        UpdateHighScores(currentPlayerName, currentPlayerScore);
    }

    private void UpdateHighScores(string currentPlayerName, int currentPlayerScore)
    {
        if (currentPlayerScore == 0)
        {
            return;
        }

        string playerName = currentPlayerName;
        int playerScore = currentPlayerScore;
        
        for (int i = 0; i < _numHighScores; i++)
        {
            string highScoreNameKey = _highScoreNameKey + i;
            string highScoreValueKey = _highScoreValueKey + i;

            if (PlayerPrefs.HasKey(highScoreNameKey) || PlayerPrefs.HasKey(highScoreValueKey))
            {
                int highScore = PlayerPrefs.GetInt(highScoreValueKey);
                if (playerScore > highScore)
                {
                    string tempName = PlayerPrefs.GetString(highScoreNameKey);
                    int tempScore = highScore;

                    PlayerPrefs.SetString(highScoreNameKey, playerName);
                    PlayerPrefs.SetInt(highScoreValueKey, playerScore);
                    PlayerPrefs.SetInt("Score", 0);

                    Debug.Log("set the high score at " + (i + 1) + " to: " + playerScore);

                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else
            {
                PlayerPrefs.SetString(highScoreNameKey, playerName);
                PlayerPrefs.SetInt(highScoreValueKey, playerScore);
                return;
            }
        }
    }

    private void DisplayHighScores()
    {
        for (int i = 0; i < _numHighScores; i++)
        {
            _highScoreNames[i].text = PlayerPrefs.GetString(_highScoreNameKey + i);
            _highScoreValues[i].text = PlayerPrefs.GetInt(_highScoreValueKey + i).ToString();
        }
    }

    private void Update()
    {
        DisplayHighScores();
    }
}
