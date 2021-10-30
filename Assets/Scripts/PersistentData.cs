using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] private string _playerName = "";
    [SerializeField] private int _score = 0;

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
        PlayerPrefs.SetInt("Score", score);
    }
}
