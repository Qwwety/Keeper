using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(!Menu.activeSelf);
            ChekMenu();
        }
    }
    
    private void ChekMenu()
    {
        if (Menu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else if (Menu.activeSelf ==false)
        {
            Time.timeScale = 1;
        }
    }
}
