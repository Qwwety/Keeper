using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject InGameMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameMenu.SetActive(!InGameMenu.activeSelf);
            OnOpenMenu();
        }
       
    }
    private void OnOpenMenu()
    {
        if (InGameMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
