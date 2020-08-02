using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneTransitions : MonoBehaviour
{
    [SerializeField] RectTransform toTransition;
    [SerializeField] LeanTweenType toTransitionType;
    [SerializeField] float moveToTransition;
    [SerializeField] float toTransitionLength;
    [SerializeField] RectTransform fromTransition;
    [SerializeField] LeanTweenType fromTransitionType;
    [SerializeField] float fromTransitionLength;
    [SerializeField] TransitionToMenu menuTransition;
    [SerializeField] RectTransform toItselfTransition;

    void Start()
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        yield return null;
        LeanTween.moveX(toTransition, moveToTransition, toTransitionLength).setEase(toTransitionType);
        GameController.QuitGame += QuitGame;
        GameController.ToShipSelection += ShipSelection;
    }

    void QuitGame()
    {
        StartCoroutine(FromTransition());
    }

    void ShipSelection()
    {
        StartCoroutine(TransitionToItself());
    }
    
    IEnumerator FromTransition()
    {
        LeanTween.moveX(fromTransition, 0, fromTransitionLength).setEase(fromTransitionType);
        yield return new WaitForSeconds(fromTransitionLength);
        SceneManager.LoadScene("MainMenu");
        menuTransition.transition = true;
        // communicate to menu that transition is needed (or do transition always)
    }

    IEnumerator TransitionToItself()
    {
        LeanTween.moveX(toItselfTransition, 0, toTransitionLength).setEase(toTransitionType);
        yield return new WaitForSeconds(toTransitionLength);
        SceneManager.LoadScene("BattleScene");
    }

    private void OnDisable()
    {
        GameController.QuitGame -= QuitGame;
        GameController.ToShipSelection -= ShipSelection;
    }
}
