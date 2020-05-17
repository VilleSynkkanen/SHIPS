﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : Effects
{
    SpriteRenderer sprite;
    float startTime;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        ActivateSprite(sprite);
        startTime = Time.time;
    }

    public override void HandleEffects()
    {

        float delta = Time.time - startTime;
        sprite.color = Color.Lerp(Visible, Invisible, delta * LerpSpeed);
        if (sprite.color == Invisible)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        HandleEffects();
    }
}