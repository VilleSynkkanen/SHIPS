using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptionsManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider effects;
    string exposedParam;

    void Awake()
    {
        
    }

    public void ExposedParam(string param)
    {
        exposedParam = param;
    }
    
    public void SetExposedParam(Slider slider) 
    {
        mixer.SetFloat(exposedParam, slider.value);
        PlayerPrefs.SetFloat(exposedParam, slider.value);
    }


}
