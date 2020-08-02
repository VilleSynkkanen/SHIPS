using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

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
    [SerializeField] RectTransform fromTransition;
    [SerializeField] LeanTweenType fromTransitionType;
    [SerializeField] float fromTransitionLength;
    [SerializeField] RectTransform toTransition;
    [SerializeField] LeanTweenType toTransitionType;
    [SerializeField] float moveToTransition;
    [SerializeField] float toTransitionLength;
    [SerializeField] TransitionToMenu transitionBool;
    [SerializeField] CanvasGroup fadeTransition;
    [SerializeField] float fadeTime;
    [SerializeField] float fadeStartDelay;

    [SerializeField] UnityEvent OnMainMenu;

    void Start()
    {
        if (transitionBool.transition)
        {
            fadeTransition.alpha = 0;
            StartCoroutine(ToTransition());
        }
            
        else
        {
            StartCoroutine(FadeDelay());
        }
        transitionBool.transition = false;
    }

    IEnumerator ToTransition()
    {
        LeanTween.scale(toTransition, Vector3.one, 0);
        yield return null;
        LeanTween.moveX(toTransition, moveToTransition, toTransitionLength).setEase(toTransitionType);
        StartCoroutine(DelayedCursor(toTransitionLength));
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(fadeStartDelay);
        LeanTween.alphaCanvas(fadeTransition, 0, fadeTime);
        StartCoroutine(DelayedCursor(fadeTime));
    }

    IEnumerator DelayedCursor(float delay)
    {
        yield return new WaitForSeconds(delay);
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
        StartCoroutine(FromTransition());
    }

    IEnumerator FromTransition()
    {
        Cursor.visible = false;
        LeanTween.moveX(fromTransition, 0, fromTransitionLength).setEase(fromTransitionType);
        yield return new WaitForSeconds(fromTransitionLength);
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