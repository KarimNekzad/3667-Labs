using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInputField : MonoBehaviour
{
    public void SetPlayerName(string input)
    {
        PlayerPrefs.SetString("Name", input);
    }
}
