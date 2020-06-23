using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShooterType { frigateCannon, frigateMine }
public enum ShipType { frigate, torpedoboat, ironclad }
public enum AimPointType { frigateCannon }
public class GameSettings : MonoBehaviour
{
    static GameSettings instance;
    public static GameSettings Instance { get { return instance; } }

    [SerializeField] ShipData[] frigateData;
    [SerializeField] ShipData[] torpedoBoatData;
    [SerializeField] ShipData[] ironcladData;
    
    [SerializeField] ShipMovementData[] frigateMovementData;
    [SerializeField] ShipMovementData[] torpedoBoatMovementData;
    [SerializeField] ShipMovementData[] ironcladMovementData;

    [SerializeField] RigidbodyData[] frigateRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatRigidbodyData;
    [SerializeField] RigidbodyData[] ironcladRigidbodyData;

    [SerializeField] AimPointData[] frigateFrontCannonAimData;
    
    [SerializeField] ChargedShooterData[] frigateCannonballShooterData;
    [SerializeField] MineShooterData[] frigateMineShooterData;
    
    [SerializeField] ProjectileData[] frigateCannonballProjectileData;
    [SerializeField] ProjectileData[] frigateMineProjectileData;
    
    [SerializeField] ProjectileGravityData[] frigateCannonballGravityData;
    
    List<ShipData[]> shipDatas;
    List<ShipMovementData[]> shipMovementDatas;
    List<RigidbodyData[]> shipRigidbodyDatas;
    List<AimPointData[]> aimPointDatas;
    List<ShooterData[]> shooterDatas;
    List<ProjectileData[]> projectileDatas;
    List<ProjectileGravityData[]> projectileGravityDatas;

    int settingNumber;

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

        shipDatas = new List<ShipData[]> { frigateData, torpedoBoatData, ironcladData };
        shipMovementDatas = new List<ShipMovementData[]> { frigateMovementData, torpedoBoatMovementData, ironcladMovementData };
        shipRigidbodyDatas = new List<RigidbodyData[]> { frigateRigidbodyData, torpedoBoatRigidbodyData, ironcladRigidbodyData };
        
        aimPointDatas = new List<AimPointData[]> { frigateFrontCannonAimData };
        
        shooterDatas = new List<ShooterData[]> { frigateCannonballShooterData, frigateMineShooterData};
        projectileDatas = new List<ProjectileData[]> { frigateCannonballProjectileData, frigateMineProjectileData };
        projectileGravityDatas = new List<ProjectileGravityData[]> { frigateCannonballGravityData, null };
    }

    public ShipData GetShipData(ShipType type)
    {
        return shipDatas[(int)type][settingNumber];
    }

    public ShipMovementData GetShipMovementData(ShipType type)
    {
        return shipMovementDatas[(int)type][settingNumber];
    }

    public RigidbodyData GetShipRigidbodyData(ShipType type)
    {
        return shipRigidbodyDatas[(int)type][settingNumber];
    }

    public AimPointData GetAimPointData(AimPointType type)
    {
        return aimPointDatas[(int)type][settingNumber];
    }

    public ShooterData GetShooterData(ShooterType type)
    {
        return shooterDatas[(int)type][settingNumber];
    }

    public ProjectileData GetProjectileData(ShooterType type)
    {
        return projectileDatas[(int)type][settingNumber];
    }

    public ProjectileGravityData GetProjectileGravityData(ShooterType type)
    {
        return projectileGravityDatas[(int)type][settingNumber];
    }
}
