using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSpeedOptionsManager : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] string[] speedNames;
    int speedSetting;

    void Start()
    {
        speedSetting = PlayerPrefs.GetInt("SpeedSetting", 1);
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
