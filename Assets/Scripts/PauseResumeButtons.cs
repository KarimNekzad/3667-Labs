using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeButtons : MonoBehaviour
{
    private GameObject[] _paused;
    private GameObject[] _resumed;

    // Start is called before the first frame update
    void Start()
    {
        _paused = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        _resumed = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        foreach (GameObject pauseModeButton in _paused)
        {
            pauseModeButton.SetActive(true);
        }

        foreach (GameObject resumeModeButton in _resumed)
        {
            resumeModeButton.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        foreach (GameObject pauseModeButton in _paused)
        {
            pauseModeButton.SetActive(false);
        }

        foreach (GameObject resumeModeButton in _resumed)
        {
            resumeModeButton.SetActive(true);
        }
    }
}
