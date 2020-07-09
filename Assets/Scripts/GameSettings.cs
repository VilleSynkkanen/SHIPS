using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShooterType { frigateCannon, frigateMine, torpedoBoatTorpedo, torpedoBoatShotgun, torpedoBoatBurstCannon }
public enum ShipType { frigate, torpedoboat, ironclad }
public enum AimPointType { frigateCannon, torpedoBoatFrontCannon, torpedoBoatRearCannon }
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
    [SerializeField] AimPointData[] torpedoBoatFrontCannonAimData;
    [SerializeField] AimPointData[] torpedoBoatRearCannonAimData;

    [SerializeField] ChargedShooterData[] frigateCannonballShooterData;
    [SerializeField] MineShooterData[] frigateMineShooterData;
    [SerializeField] TorpedoShooterData[] torpedoBoatTorpedoShooterData;
    [SerializeField] ShotgunShooterData[] torpedoBoatShotgunData;
    [SerializeField] BurstShooterData[] torpedoBoatBurstCannonData;
    
    [SerializeField] ProjectileData[] frigateCannonballProjectileData;
    [SerializeField] ProjectileData[] frigateMineProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatTorpedoProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatCannonballProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatShotgunShotProjectileData;

    [SerializeField] RigidbodyData[] frigateCannonballRigidbodyData;
    [SerializeField] RigidbodyData[] frigateMineRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatTorpedoRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatCannonballRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatShotgunShotRigidbodyData;

    [SerializeField] ProjectileGravityData[] frigateCannonballGravityData;
    [SerializeField] ProjectileGravityData[] torpedoBoatCannonballGravityData;
    [SerializeField] ProjectileGravityData[] torpedoBoatShotgunShotGravityData;

    List<ShipData[]> shipDatas;
    List<ShipMovementData[]> shipMovementDatas;
    List<RigidbodyData[]> shipRigidbodyDatas;
    List<AimPointData[]> aimPointDatas;
    List<ShooterData[]> shooterDatas;
    List<ProjectileData[]> projectileDatas;
    List<RigidbodyData[]> projectileRigidbodyDatas;
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
        
        aimPointDatas = new List<AimPointData[]> { frigateFrontCannonAimData, torpedoBoatFrontCannonAimData, torpedoBoatRearCannonAimData };
                                                                                                                                      
        shooterDatas = new List<ShooterData[]> { frigateCannonballShooterData, frigateMineShooterData, torpedoBoatTorpedoShooterData,
            torpedoBoatShotgunData, torpedoBoatBurstCannonData };
        projectileDatas = new List<ProjectileData[]> { frigateCannonballProjectileData, frigateMineProjectileData, 
            torpedoBoatTorpedoProjectileData, torpedoBoatShotgunShotProjectileData, torpedoBoatCannonballProjectileData };
        projectileRigidbodyDatas = new List<RigidbodyData[]> { frigateCannonballRigidbodyData, frigateMineRigidbodyData, 
            torpedoBoatTorpedoRigidbodyData, torpedoBoatShotgunShotRigidbodyData, torpedoBoatCannonballRigidbodyData };
        projectileGravityDatas = new List<ProjectileGravityData[]> { frigateCannonballGravityData, null, null, torpedoBoatShotgunShotGravityData, 
            torpedoBoatCannonballGravityData };
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

    public RigidbodyData GetProjectileRigidbodyData(ShooterType type)
    {
        return projectileRigidbodyDatas[(int)type][settingNumber];
    }
}
