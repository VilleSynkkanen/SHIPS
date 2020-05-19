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
    [SerializeField] Color[] defaultColors;
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

            float red = PlayerPrefs.GetFloat(keyR, -1);
            if(red == -1)
            {
                reds[i].value = defaultColors[i].r;
            }
            else
            {
                reds[i].value = red;
            }
            PlayerPrefs.SetFloat(keyR, reds[i].value);

            float green = PlayerPrefs.GetFloat(keyG, -1);
            if (green == -1)
            {
                greens[i].value = defaultColors[i].g;
            }
            else
            {
                greens[i].value = green;
            }
            PlayerPrefs.SetFloat(keyG, greens[i].value);

            float blue = PlayerPrefs.GetFloat(keyB, -1);
            if (blue == -1)
            {
                blues[i].value = defaultColors[i].b;
            }
            else
            {
                blues[i].value = blue;
            }
            PlayerPrefs.SetFloat(keyB, blues[i].value);

            SetColor(i, "P" + (i + 1).ToString());
        }
    }

    public void OnSliderChanged(string id)     // eg. P1R
    {
        int i = int.Parse("" + id[1]) - 1;
        if(names != null)
        {
            Slider[] sliders = names[id[2]];
            PlayerPrefs.SetFloat(id, sliders[i].value);
        }
        string player = "" + id[0] + id[1];
        SetColor(i, player);
    }

    public void SetColor(int i, string player)
    {
        colors[i].color = new Color(PlayerPrefs.GetFloat(player + "R", 0), PlayerPrefs.GetFloat(player + "G", 0)
            , PlayerPrefs.GetFloat(player + "B", 0));
    }
}
