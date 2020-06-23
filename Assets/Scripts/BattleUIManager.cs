using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] GameObject victoryUi;
    [SerializeField] TextMeshProUGUI[] victoryTexts;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject playAgainButton;

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

        victoryUi.SetActive(true);
        eventSystem.SetSelectedGameObject(playAgainButton);
    }

    public void HideVictoryUI()
    {
        victoryUi.SetActive(false);
    }
}
