using UnityEngine;
using TMPro;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] GameObject[] ships;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] RectTransform rectTrans;
    [SerializeField] PlayerColorController colorController;
    public int i { get; private set; }

    private void Awake()
    {
        i = 0;
    }

    public void SetPlayerText(string txt)
    {
        text.text = txt;
    }
    
    public void NextShip()
    {
        ships[i].SetActive(false);
        i++;
        if (i == ships.Length)
        {
            i = 0;
            ships[i].SetActive(true);
        }
        else
        {
            ships[i].SetActive(true);
        }
    }

    public void PreviousShip()
    {
        ships[i].SetActive(false);
        i--;
        if (i == -1)
        {
            i = ships.Length - 1;
            ships[i].SetActive(true);
        }
        else
        {
            ships[i].SetActive(true);
        }
    }

    public void SetUI(int i, bool ready=false)
    {
        Vector2 pivot;
        Vector2 anchorMin;
        Vector2 anchorMax;

        if (i == 0)
        {
            pivot = Vector2.zero;
            anchorMin = Vector2.zero;
            anchorMax = Vector2.zero;
        }
        else if (i == 1)
        {
            pivot = Vector2.right;
            anchorMin = Vector2.right;
            anchorMax = Vector2.right;
        }
        else if (i == 2)
        {
            pivot = Vector2.up;
            anchorMin = Vector2.up;
            anchorMax = Vector2.up;
        }
        else
        {
            pivot = Vector2.right + Vector2.up;
            anchorMin = Vector2.right + Vector2.up;
            anchorMax = Vector2.right + Vector2.up;
        }

        rectTrans.pivot = pivot;
        rectTrans.anchoredPosition = Vector3.zero;
        rectTrans.anchorMin = anchorMin;
        rectTrans.anchorMax = anchorMax;


        if(!ready)
            SetPlayerText("P" + (i + 1).ToString() + " JOINED");
        else
            SetPlayerText("P" + (i + 1).ToString() + " READY");
        colorController.UpdateColor();
    }

}
