using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] ProjectileGravityData data;
    [SerializeField] GameObject waterHitEffect;

    float altitude;
    float downwardVelocity;

    private void Awake()
    {
        altitude = data.startingAltitude;
        downwardVelocity = 0;
    }

    void Update()
    {
        downwardVelocity += data.acceleration * Time.deltaTime;
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