using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] private string _playerName = "";
    [SerializeField] private int _score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _playerNameText;

    public static PersistentData instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _playerName = PlayerPrefs.GetString("Name");
        _playerNameText.text = "Player: " + _playerName;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;
    }

    public string GetName()
    {
        return _playerName;
    }

    public void SetName(string name)
    {
        _playerName = name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }
}
