using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject NewGame;
    [SerializeField] public Slider VolumeSlider;

    public void NewGameClick()
    {
        SaveLoad.SaveSound(VolumeSlider.value);
        SceneManager.LoadScene(1);
    }
}
