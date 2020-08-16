using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform mainMenu;
    [SerializeField] RectTransform playMenu;
    [SerializeField] RectTransform howToPlayMenu;
    [SerializeField] RectTransform optionsMenu;
    [SerializeField] RectTransform creditsMenu;
    [SerializeField] float[] menusHidden;
    [SerializeField] float[] menusVisible;
    [SerializeField] float menuAnimationTime;
    [SerializeField] LeanTweenType menuFromTransitionType;
    [SerializeField] LeanTweenType menuToTransitionType;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject menuStart;
    [SerializeField] GameObject playMenuStart;
    [SerializeField] GameObject howToPlayStart;
    [SerializeField] GameObject optionsStart;
    [SerializeField] GameObject creditsStart;
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
    
    int activeMenu;
    List<RectTransform> menus;

    [SerializeField] UnityEvent OnMainMenu;

    void Start()
    {
        menus = new List<RectTransform> { mainMenu, playMenu, howToPlayMenu, optionsMenu, creditsMenu };
        activeMenu = 0;
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
    
    void ActivateMenu(int i)
    {
        activeMenu = i;
        LeanTween.moveY(menus[i], menusVisible[i], menuAnimationTime).setEase(menuToTransitionType);
    }
    
    void DeactivateMenu(int i)
    {
        LeanTween.moveY(menus[i], menusHidden[i], menuAnimationTime).setEase(menuFromTransitionType);
    }
    
    public void ToMainMenu()
    {
        DeactivateMenu(activeMenu);
        ActivateMenu(0);
        eventSystem.SetSelectedGameObject(menuStart);
        OnMainMenu.Invoke();
    }
    public void PlayMenu()
    {
        DeactivateMenu(activeMenu);
        ActivateMenu(1);
        eventSystem.SetSelectedGameObject(playMenuStart);
    }

    public void Play()
    {
        StartCoroutine(FromTransition());
    }

    IEnumerator FromTransition()
    {
        Cursor.visible = false;
        MusicPlayer.instance.FadeMusic(-1, FadeType.clipSwitch);
        LeanTween.moveX(fromTransition, 0, fromTransitionLength).setEase(fromTransitionType);
        yield return new WaitForSeconds(fromTransitionLength);
        SceneManager.LoadScene("BattleScene");
    }

    public void HowToPlayMenu()
    {
        DeactivateMenu(activeMenu);
        ActivateMenu(2);
        eventSystem.SetSelectedGameObject(howToPlayStart);
    }

    public void OptionsMenu()
    {
        DeactivateMenu(activeMenu);
        ActivateMenu(3);
        eventSystem.SetSelectedGameObject(optionsStart);
    }

    public void CreditsMenu()
    {
        DeactivateMenu(activeMenu);
        ActivateMenu(4);
        eventSystem.SetSelectedGameObject(creditsStart);
    }

    public void Quit()
    {
        Application.Quit();
    }
}