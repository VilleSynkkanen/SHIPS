using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float startingAltitude;
    [SerializeField] GameObject waterHitEffect;

    float altitude;
    float downwardVelocity;

    private void Awake()
    {
        altitude = startingAltitude;
        downwardVelocity = 0;
    }

    void Update()
    {
        downwardVelocity += acceleration * Time.deltaTime;
    }

    void FixedUpdate()
    {
        altitude -= downwardVelocity * Time.fixedDeltaTime;

        if(altitude <= 0)
        {
            HitSea();
        }
    }

    void HitSea()
    {
        Instantiate(waterHitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
