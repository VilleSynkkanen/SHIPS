using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShooterType { cannon, mine }
public class GameSettings : MonoBehaviour
{
    static GameSettings instance;
    public static GameSettings Instance { get { return instance; } }

    [SerializeField] ShipData[] shipData;
    [SerializeField] ChargedShooterData[] cannonballShooterData;
    [SerializeField] ShipMovementData[] shipMovementData;
    [SerializeField] AimPointData[] frontCannonData;
    [SerializeField] ProjectileData[] cannonballProjectileData;
    [SerializeField] ProjectileGravityData[] cannonballGravityData;
    [SerializeField] ProjectileData[] mineProjectileData;
    [SerializeField] MineShooterData[] mineShooterData;
    [SerializeField] RigidbodyData[] shipRigidbodyData;
    int settingNumber;

    public ShipData ShipData { get => shipData[settingNumber]; }
    public ChargedShooterData CannonballShooterData { get => cannonballShooterData[settingNumber]; }
    public ShipMovementData ShipMovementData { get => shipMovementData[settingNumber]; }
    public AimPointData FrontCannonData { get => frontCannonData[settingNumber]; }
    public ProjectileData CannonballProjectileData { get => cannonballProjectileData[settingNumber]; }
    public ProjectileGravityData CannonballGravityData { get => cannonballGravityData[settingNumber]; }
    public ProjectileData MineProjectileData { get => mineProjectileData[settingNumber]; }
    public MineShooterData MineShooterData{ get => mineShooterData[settingNumber]; }
    public RigidbodyData ShipRigidbodyData { get => shipRigidbodyData[settingNumber]; }

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

    public ShooterData GetShooterData(ShooterType type)
    {
        if (type == ShooterType.cannon)
        {
            return CannonballShooterData;
        }
        else if (type == ShooterType.mine)
        {
            return MineShooterData;
        }
        else
        {
            return null;
        }
    }
}
