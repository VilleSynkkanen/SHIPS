using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] RectTransform movingUi;
    [SerializeField] Button[] victoryButtons;
    [SerializeField] RectTransform[] buttonTransforms;
    [SerializeField] GameObject[] backgrounds;
    [SerializeField] TextMeshProUGUI[] victoryTexts;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] float movingUiHiddenPlace;
    [SerializeField] float uiMoveTime;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
        HideVictoryUI();
    }

    public void ShowVictoryUi(int winner, int[] victories)      // winner = -1 if draw
    {
        if(winner == -1)
            winnerText.text = "DRAW!";
        else
            winnerText.text = "PLAYER " + (winner + 1).ToString() + " WON!";

        for (int i = 0; i < victoryTexts.Length; i++)
        {
            if(i >= controller.Victories.playerVictories.Length)
            {
                victoryTexts[i].text = "";
            }
            else
            {
                victoryTexts[i].text =  "PLAYER " + (i + 1).ToString() + " VICTORIES: " + controller.Victories.playerVictories[i].ToString();
            }
        }

        eventSystem.SetSelectedGameObject(playAgainButton);
        SetButtonPlacement(controller.Victories.playerVictories.Length);        // should do only once
        LeanTween.moveY(movingUi, 0, uiMoveTime).setEase(LeanTweenType.easeOutBack);
        StartCoroutine(SetButtonState(uiMoveTime, true));
    }

    public void HideVictoryUI()
    {
        LeanTween.moveY(movingUi, movingUiHiddenPlace, uiMoveTime).setEase(LeanTweenType.easeInBack);
        StartCoroutine(SetButtonState(0, false));
    }

    IEnumerator SetButtonState(float waitTime, bool interactable)
    {
        yield return new WaitForSeconds(waitTime);
        foreach(Button button in victoryButtons)
        {
            button.interactable = interactable;
        }
    }

    void SetButtonPlacement(int players)
    {
        foreach (RectTransform button in buttonTransforms)
        {
            button.anchoredPosition = new Vector3(button.anchoredPosition.x, (4 - players) * 70 - 300);
        }
        for(int i = 0; i < backgrounds.Length; i++)
        {
            if(i == players - 1)
            {
                backgrounds[i].SetActive(true);
            }
            else
            {
                backgrounds[i].SetActive(false);
            }
        }
    }
}
