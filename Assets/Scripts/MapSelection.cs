using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    [SerializeField] Sprite[] mapImages;
    [SerializeField] Image image;
    [SerializeField] PlayerVictories victories;

    private void Awake()
    {
        UpdateMap();
    }

    public void Next()
    {
        victories.mapIndex++;
        if(victories.mapIndex == mapImages.Length)
        {
            victories.mapIndex = 0;
        }
        UpdateMap();
    }

    public void Previous()
    {
        victories.mapIndex--;
        if (victories.mapIndex == -1)
        {
            victories.mapIndex = mapImages.Length - 1;
        }
        UpdateMap();
    }

    void UpdateMap()
    {
        image.sprite = mapImages[victories.mapIndex];
    }
}
