using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct EffectInfo
{
    public SpriteRenderer[] sprites;
    public bool active;
}

public class ShotEffects : Effects
{
    [SerializeField] SpriteRenderer[] left;
    [SerializeField] SpriteRenderer[] right;
    [SerializeField] SpriteRenderer[] forward;

    EffectInfo[] effects = new EffectInfo[3];

    float startTime;
    
    void Awake()
    {
        for (int i = 0; i < effects.Length; i++)
            effects[i] = new EffectInfo();

        effects[0].sprites = left;
        effects[1].sprites = right;
        effects[2].sprites = forward;
    }

    public void Effect(Side side)
    {
        int i = (int)side;

        foreach (SpriteRenderer effect in effects[i].sprites)
        {
            ActivateSprite(effect);
        }
        effects[i].active = true;
        startTime = Time.time;
    }

    public override void HandleEffects()
    {
        float delta = Time.time - startTime;
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i].active)
            {
                foreach (SpriteRenderer effect in effects[i].sprites)
                {
                    effect.color = Color.Lerp(Visible, Invisible, delta * LerpSpeed);
                    if (effect.color == Invisible)
                    {
                        effects[i].active = false;
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