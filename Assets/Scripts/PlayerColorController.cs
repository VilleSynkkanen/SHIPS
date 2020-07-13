using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorController : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] sprites;
    [SerializeField] Image[] images;
    DeviceAssignmentControls assignment;

    private void Awake()
    {
        assignment = GetComponent<DeviceAssignmentControls>();
        UpdateColor();
    }

    public void UpdateColor()
    {
        string tag;
        if (assignment != null)
            tag = "P" + (assignment.plrIndex + 1).ToString();
        else
            tag = gameObject.tag;
        float red = PlayerPrefs.GetFloat(tag + "R", 1);
        float green = PlayerPrefs.GetFloat(tag + "G", 1);
        float blue = PlayerPrefs.GetFloat(tag + "B", 1);
        Color color = new Color(red, green, blue);

        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = color;
        }
        foreach (Image image in images)
        {
            image.color = color;
        }
    }
}
