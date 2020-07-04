using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shooter : MonoBehaviour
{
    ShooterData data;
    [SerializeField] Transform[] shotLocations;
    [SerializeField] GameObject projectile;
    [SerializeField] Vector2 recoil;
    [SerializeField] UnityEvent ShotEvent;
    [SerializeField] ShooterType type;

    public ShooterData Data { get => data; }

    public float cooldownLeft { get; private set; }
    public int ammoLeft { get; private set; }
    public Transform[] ShotLocations { get => shotLocations; }
    public GameObject Projectile { get => projectile; }
    public Vector2 Recoil { get => recoil; set => recoil = value; }

    public abstract void ShotInput(bool input);
    public abstract void Shoot();

    private void Awake()
    {
        data = GameSettings.Instance.GetShooterData(type);
        ResetState();
    }

    public void ResetState()
    {
        ammoLeft = data.StartingAmmo;
        cooldownLeft = 0;
    }

    private void Update()
    {
        UpdateCooldown();
    }

    public void UpdateCooldown()
    {
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
        }
    }

    public void SetCooldown(float time)
    {
        cooldownLeft = time;
    }

    public void ExpendAmmo()
    {
        ammoLeft--;
    }

    public void TriggerShotEvent()
    {
        ShotEvent.Invoke();
    }
}
