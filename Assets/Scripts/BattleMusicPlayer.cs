using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicPlayer : MusicPlayer
{
    [SerializeField] AudioClip[] audioClips;

    public void SwitchToClip(int i, bool fadeOut)
    {
        StartCoroutine(SwitchClip(i, fadeOut));
    }

    IEnumerator SwitchClip(int i, bool fadeOut)
    {
        if(fadeOut)
        {
            FadeMusic(-1, FadeType.clipSwitch);
            yield return new WaitForSeconds(1 / FadeSpeed[fadeIndex]);
        }
        yield return new WaitForSeconds(0);
        Music.clip = audioClips[i];
        Music.Play();
        FadeMusic(1, FadeType.clipSwitch);
    }
}
