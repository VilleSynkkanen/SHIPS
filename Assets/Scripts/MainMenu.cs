using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] GameObject howToPlayMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] PlayerVictories victories;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject menuStart;
    [SerializeField] GameObject playMenuStart;
    [SerializeField] GameObject howToPlayStart;
    [SerializeField] GameObject optionsStart;

    void Awake()
    {
        Cursor.visible = true;
    }

    public void ToMainMenu()
    {
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
        optionsMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(menuStart);
    }
    public void PlayMenu()
    {
        playMenu.SetActive(true);
        mainMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(playMenuStart);
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
        eventSystem.SetSelectedGameObject(howToPlayStart);
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(optionsStart);
    }

    public void Quit()
    {
        Application.Quit();
    }
}