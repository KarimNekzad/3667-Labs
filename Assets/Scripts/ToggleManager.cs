using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    [SerializeField] private GameObject _difficultyOptions;
    public void OnToggle(bool value)
    {
        _difficultyOptions.SetActive(value);
    }
}
