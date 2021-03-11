using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] public Slider VolumeSlider;

    public void ExitClick()
    {
        SaveLoad.SaveSound(VolumeSlider.value);
        Application.Quit();
    }
}
