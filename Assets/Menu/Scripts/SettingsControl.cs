using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    [SerializeField] private Dropdown ResolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {

        resolutions=Screen.resolutions;

        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int CurentReolutionIndex = 0;
        for (int i=0;i<resolutions.Length;i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width== Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurentReolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurentReolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
}
