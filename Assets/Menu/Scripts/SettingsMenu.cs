using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject HideButton;

   
    public void SettingsClick()
    {
        Settings.SetActive(!Settings.activeSelf);
        HideButton.SetActive(!HideButton.activeSelf);
    }
}
