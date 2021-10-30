using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void OnValueChange(float volume)
    {
        AudioListener.volume = volume;
    }
}
