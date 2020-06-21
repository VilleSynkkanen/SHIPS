using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    ProjectileGravityData data;
    [SerializeField] GameObject waterHitEffect;

    float altitude;
    float downwardVelocity;

    private void Awake()
    {
        data = GameSettings.Instance.CannonballGravityData;
        altitude = data.StartingAltitude;
        downwardVelocity = 0;
    }

    void Update()
    {
        downwardVelocity += data.Acceleration * Time.deltaTime;
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