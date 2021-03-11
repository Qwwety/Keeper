using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSound : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private AudioSource Audio;

    private void Start()
    {
        try
        {
            PlayerData PlayerDataSound = SaveLoad.LoadSound();
            Slider.value = PlayerDataSound.Volume;
            Audio.volume = Slider.value;
        }
        catch
        {
            Debug.Log("LoadSound Problems");
        }
    }
}
