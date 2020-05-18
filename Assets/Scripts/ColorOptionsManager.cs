using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOptionsManager : MonoBehaviour
{
    [SerializeField] Slider[] reds;
    [SerializeField] Slider[] greens;
    [SerializeField] Slider[] blues;
    [SerializeField] Image[] colors;
    Dictionary<char, Slider[]> names;

    void Awake()
    {
        names = new Dictionary<char, Slider[]>();
        names['R'] = reds;
        names['G'] = greens;
        names['B'] = blues;

        for(int i = 0; i < reds.Length; i++)
        {
            string keyR = "P" + (i + 1).ToString() + "R";
            string keyG = "P" + (i + 1).ToString() + "G";
            string keyB = "P" + (i + 1).ToString() + "B";

            reds[i].value = PlayerPrefs.GetFloat(keyR, 1);
            greens[i].value = PlayerPrefs.GetFloat(keyG, 1);
            blues[i].value = PlayerPrefs.GetFloat(keyB, 1);
        }
    }

    public void OnSliderChanged(string id)     // eg. P1R
    {
        int i = int.Parse("" + id[1]) - 1;
        print(id[2]);
        Slider[] sliders = names[id[2]];
        PlayerPrefs.SetFloat(id, sliders[i].value);

        string player = "" + id[0] + id[1];
        colors[i].color = new Color(PlayerPrefs.GetFloat(player + "R", 0), PlayerPrefs.GetFloat(player + "G", 0)
            , PlayerPrefs.GetFloat(player + "B", 0));
    }
}
