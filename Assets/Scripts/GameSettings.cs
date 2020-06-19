using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    static GameSettings instance;
    public static GameSettings Instance { get { return instance; } }

    [SerializeField] ShipData[] shipData;
    [SerializeField] ShipShooterData[] shipShooterData;
    [SerializeField] ShipMovementData[] shipMovementData;
    [SerializeField] FrontCannonData[] frontCannonData;
    [SerializeField] ProjectileData[] cannonballProjectileData;
    [SerializeField] ProjectileGravityData[] cannonballGravityData;
    [SerializeField] ProjectileData[] mineProjectileData;
    [SerializeField] MineData[] mineData;
    int settingNumber;

    public ShipData ShipData { get => shipData[settingNumber]; }
    public ShipShooterData ShipShooterData { get => shipShooterData[settingNumber]; }
    public ShipMovementData ShipMovementData { get => shipMovementData[settingNumber]; }
    public FrontCannonData FrontCannonData { get => frontCannonData[settingNumber]; }
    public ProjectileData CannonballProjectileData { get => cannonballProjectileData[settingNumber]; }
    public ProjectileGravityData CannonballGravityData { get => cannonballGravityData[settingNumber]; }
    public ProjectileData MineProjectileData { get => mineProjectileData[settingNumber]; }
    public MineData MineData { get => mineData[settingNumber]; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        settingNumber = PlayerPrefs.GetInt("SpeedSetting", 0);
    }
}
