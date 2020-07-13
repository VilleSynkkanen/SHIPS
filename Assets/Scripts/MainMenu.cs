using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] GameObject howToPlayMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject menuStart;
    [SerializeField] GameObject playMenuStart;
    [SerializeField] GameObject howToPlayStart;
    [SerializeField] GameObject optionsStart;

    [SerializeField] UnityEvent OnMainMenu;

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
        OnMainMenu.Invoke();
    }
    public void PlayMenu()
    {
        playMenu.SetActive(true);
        mainMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(playMenuStart);
    }

    public void Play()
    {
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