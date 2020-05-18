using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Image image;

    private void Awake()
    {
        string tag = gameObject.tag;
        float red = PlayerPrefs.GetFloat(tag + "R", 1);
        float green = PlayerPrefs.GetFloat(tag + "G", 1);
        float blue = PlayerPrefs.GetFloat(tag + "B", 1);
        Color color = new Color(red, green, blue);
        sprite.color = color;
        image.color = color;
    }
}
