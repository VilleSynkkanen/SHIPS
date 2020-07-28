using UnityEngine;
using System.Collections.Generic;

public class ShotEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem[] effects0;
    [SerializeField] ParticleSystem[] effects1;
    [SerializeField] ParticleSystem[] effects2;
    [SerializeField] ParticleSystem[] effects3;
    List<ParticleSystem[]> effects = new List<ParticleSystem[]>();

    private void Awake()
    {
        effects.Add(effects0);
        effects.Add(effects1);
        effects.Add(effects2);
        effects.Add(effects3);
    }

    public void Effect(int i)
    {
        foreach (ParticleSystem effect in effects[i])
        {
            effect.Play();
        }
    }
}