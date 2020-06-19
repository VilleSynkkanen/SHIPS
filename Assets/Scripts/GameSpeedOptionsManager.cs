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
    
    void Awake()
    {
        speedSetting = PlayerPrefs.GetInt("SpeedSetting", 0);
        speedSlider.value = speedSetting;
    }

    public void OnSliderValueChanged()
    {
        speedSetting = (int)speedSlider.value;
        speedText.text = "SPEED: " + speedSetting.ToString();
        PlayerPrefs.SetInt("SpeedSetting", speedSetting);
    }
}
