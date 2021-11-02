using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
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

    private void Update()
    {
        PlayerPrefs.GetString("Name");
    }

    public string GetName()
    {
        return PlayerPrefs.GetString("Name");
    }

    public void SetName(string name)
    {
        PlayerPrefs.SetString("Name", name);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("Score"); ;
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public int GetLevel()
    {
        return SceneManager.GetActiveScene().buildIndex - 2;
    }
}
