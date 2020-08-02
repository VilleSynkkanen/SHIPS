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
    [SerializeField] TextMeshProUGUI[] victoryTexts;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] float movingUiHiddenPlace;
    [SerializeField] float uiMoveTime;
    [SerializeField] float uiWaitTimeMultiplier;
    [SerializeField] float victoryAdditionTime;
    [SerializeField] AudioSource addVictorySound;
    bool gameEnded;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
        DeviceAssignment.VictoriesSetup += SetupVictoryUI;
        gameEnded = false;
    }

    public void SetupVictoryUI()
    {
        for (int i = 0; i < victoryTexts.Length; i++)
        {
            if (i >= controller.Victories.playerVictories.Length)
            {
                victoryTexts[i].text = "";
            }
            else
            {
                victoryTexts[i].text = "PLAYER " + (i + 1).ToString() + " VICTORIES: " + controller.Victories.playerVictories[i].ToString();
            }
        }

        SetButtonPlacement(controller.Victories.playerVictories.Length);
    }
    
    public void ShowVictoryUi(int winner, int[] victories)      // winner = -1 if draw
    {
        if(!gameEnded)
        {
            gameEnded = true;
            if(winner == -1)
                winnerText.text = "DRAW!";
            else
            {
                winnerText.text = "PLAYER " + (winner + 1).ToString() + " WON!";
                StartCoroutine(AddVictory(winner));
            }
            
            LeanTween.moveY(movingUi, 0, uiMoveTime).setEase(LeanTweenType.easeOutBack);
            StartCoroutine(SetButtonState(uiWaitTimeMultiplier * uiMoveTime, true));
        }    
    }

    public void HideVictoryUI()
    {
        gameEnded = false;
        LeanTween.moveY(movingUi, movingUiHiddenPlace, uiMoveTime).setEase(LeanTweenType.easeInBack);
        StartCoroutine(SetButtonState(0, false));
    }

    IEnumerator SetButtonState(float waitTime, bool interactable)
    {
        if(!interactable)
        {
            eventSystem.SetSelectedGameObject(null);
        }

        yield return new WaitForSeconds(waitTime);
        foreach(Button button in victoryButtons)
        {
            button.interactable = interactable;
        }

        if(interactable)
        {
            eventSystem.SetSelectedGameObject(playAgainButton);
        }
    }

    IEnumerator AddVictory(int i)
    {
        yield return new WaitForSeconds(victoryAdditionTime);
        victoryTexts[i].text = "PLAYER " + (i + 1).ToString() + " VICTORIES: " + controller.Victories.playerVictories[i].ToString();
        addVictorySound.Play();
    }

    void SetButtonPlacement(int players)
    {
        foreach (RectTransform button in buttonTransforms)
        {
            button.anchoredPosition = new Vector3(button.anchoredPosition.x, (4 - players) * 75 - 375);   
        }
    }

    private void OnDisable()
    {
        DeviceAssignment.VictoriesSetup -= SetupVictoryUI;
    }
}
