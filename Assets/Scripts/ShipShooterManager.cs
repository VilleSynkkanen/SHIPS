using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooterManager : MonoBehaviour
{
    [SerializeField] Shooter[] shooters;
    [SerializeField] Shooter[] aimableShooters;
    PlayerControlInput input;
    bool[] shotInputs = new bool[4];

    public Shooter[] AimableShooters { get => aimableShooters; }
    public Shooter[] Shooters { get => shooters; }

    private void Awake()
    {
        input = GetComponent<PlayerControlInput>();
    }

    public void ResetShooters()
    {
        foreach(Shooter shooter in shooters)
        {
            shooter.ResetState();
        }
    }
    
    private void Update()
    {
        ReadInput();
        SendInput();
    }

    void ReadInput()
    {
        shotInputs[0] = input.shoot1;
        shotInputs[1] = input.shoot2;
        shotInputs[2] = input.shoot3;
        shotInputs[3] = input.shoot4;
    }

    void SendInput()
    {
        for(int i = 0; i < Shooters.Length; i++)
        {
            Shooters[i].ShotInput(shotInputs[i]);
        }
    }
}
