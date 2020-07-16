using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettingsController : MonoBehaviour
{
    [SerializeField] TMP_Dropdown textures;
    [SerializeField] TMP_Dropdown vsync;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        textures.value = PlayerPrefs.GetInt("TextureQuality", 2);
        QualitySettings.SetQualityLevel(textures.value);
        vsync.value = PlayerPrefs.GetInt("VSync", 0);
        QualitySettings.vSyncCount = vsync.value;
        ManageResolutions();
    }

    void ManageResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetTextureQuality(int amount)
    {
        QualitySettings.SetQualityLevel(amount);
        PlayerPrefs.SetInt("TextureQuality", amount);
    }

    public void SetVsyncValue(int amount)
    {
        QualitySettings.vSyncCount = amount;
        PlayerPrefs.SetInt("VSync", amount);
    }

    public void SetResolution(int i)
    {
        // saved automatically
        Screen.SetResolution(resolutions[i].width, resolutions[i].height, Screen.fullScreen);
    }

    public void SetFullscreen(bool fullScreen)
    {
        // saved automatically
        Screen.fullScreen = fullScreen;
    }
}
