using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSpeedOptionsManager : MonoBehaviour
{
    int speedSetting;
    [SerializeField] Slider speedSlider;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] string[] speedNames;
    
    void Start()
    {
        speedSetting = PlayerPrefs.GetInt("SpeedSetting", 0);
        speedSlider.value = speedSetting;
        speedText.text = "SPEED: " + speedNames[speedSetting];
    }

    public void OnSliderValueChanged()
    {
        speedSetting = (int)speedSlider.value;
        speedText.text = "SPEED: " + speedNames[speedSetting];
        PlayerPrefs.SetInt("SpeedSetting", speedSetting);
    }
}
