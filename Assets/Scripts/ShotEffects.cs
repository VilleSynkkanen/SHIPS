using UnityEngine;
using System.Collections.Generic;


public class ShotEffects : Effects
{
    [SerializeField] SpriteRenderer[] effects0;
    [SerializeField] SpriteRenderer[] effects1;
    [SerializeField] SpriteRenderer[] effects2;
    [SerializeField] SpriteRenderer[] effects3;
    List<SpriteRenderer[]> effects = new List<SpriteRenderer[]>();
    bool[] active = new bool[4];
    float[] startTime = new float[4];

    private void Awake()
    {
        effects.Add(effects0);
        effects.Add(effects1);
        effects.Add(effects2);
        effects.Add(effects3);
    }

    public void Effect(int i)
    {
        foreach (SpriteRenderer effect in effects[i])
        {
            ActivateSprite(effect);
        }
        active[i] = true;
        startTime[i] = Time.time;
    }

    public override void HandleEffects()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            float delta = Time.time - startTime[i];
            if (active[i])
            {
                foreach (SpriteRenderer effect in effects[i])
                {
                    effect.color = Color.Lerp(Visible, Invisible, delta * LerpSpeed);
                    if (effect.color == Invisible)
                    {
                        active[i] = false;
                    }
                }
            }
        }
    }
    
    void Update()
    {
        HandleEffects();
    }
}