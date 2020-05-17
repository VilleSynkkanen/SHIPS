using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] GameObject howToPlayMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] PlayerVictories victories;

    public void ToMainMenu()
    {
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
    public void PlayMenu()
    {
        playMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Play(int amount)
    {
        victories.playerVictories = new int[amount];
        PlayerPrefs.SetInt("players", amount);
        SceneManager.LoadScene("BattleScene");
    }

    public void HowToPlayMenu()
    {
        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void  OptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}