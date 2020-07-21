using System.Collections.Generic;
using UnityEngine;

public enum ShooterType { frigateCannon, frigateMine, torpedoBoatTorpedo, torpedoBoatShotgun, torpedoBoatBurstCannon, 
    ironcladCannon, ironcladFlamethrower, shipXCannon }
public enum ShipType { frigate, torpedoboat, ironclad, shipX }
public enum AimPointType { frigateCannon, torpedoBoatRearCannon, ironcladCannnon }
public class GameSettings : MonoBehaviour
{
    static GameSettings instance;
    public static GameSettings Instance { get { return instance; } }

    [SerializeField] ShipData[] frigateData;
    [SerializeField] ShipData[] torpedoBoatData;
    [SerializeField] ShipData[] ironcladData;
    [SerializeField] ShipData[] shipXData;

    [SerializeField] ShipMovementData[] frigateMovementData;
    [SerializeField] ShipMovementData[] torpedoBoatMovementData;
    [SerializeField] ShipMovementData[] ironcladMovementData;
    [SerializeField] ShipMovementData[] shipXMovementData;

    [SerializeField] RigidbodyData[] frigateRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatRigidbodyData;
    [SerializeField] RigidbodyData[] ironcladRigidbodyData;
    [SerializeField] RigidbodyData[] shipXRigidbodyData;

    [SerializeField] AimPointData[] frigateFrontCannonAimData;
    [SerializeField] AimPointData[] torpedoBoatRearCannonAimData;
    [SerializeField] AimPointData[] ironcladCannonAimData;

    [SerializeField] ChargedShooterData[] frigateCannonballShooterData;
    [SerializeField] MineShooterData[] frigateMineShooterData;
    [SerializeField] TorpedoShooterData[] torpedoBoatTorpedoShooterData;
    [SerializeField] ShotgunShooterData[] torpedoBoatShotgunData;
    [SerializeField] BurstShooterData[] torpedoBoatBurstCannonData;
    [SerializeField] ChargedShooterData[] ironcladCannonballShooterData;
    [SerializeField] FlamethrowerShooterData[] ironcladFlamethrowerShooterData;
    [SerializeField] ChargedShooterData[] shipXCannonShooterData;

    [SerializeField] ProjectileData[] frigateCannonballProjectileData;
    [SerializeField] ProjectileData[] frigateMineProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatTorpedoProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatCannonballProjectileData;
    [SerializeField] ProjectileData[] torpedoBoatShotgunShotProjectileData;
    [SerializeField] ProjectileData[] ironcladCannonballProjectileData;
    [SerializeField] ProjectileData[] shipXProjectileData;

    [SerializeField] RigidbodyData[] frigateCannonballRigidbodyData;
    [SerializeField] RigidbodyData[] frigateMineRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatTorpedoRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatCannonballRigidbodyData;
    [SerializeField] RigidbodyData[] torpedoBoatShotgunShotRigidbodyData;
    [SerializeField] RigidbodyData[] ironcladCannonballRigidbodyData;
    [SerializeField] RigidbodyData[] shipXCannonballRigidbodyData;

    [SerializeField] ProjectileGravityData[] frigateCannonballGravityData;
    [SerializeField] ProjectileGravityData[] torpedoBoatCannonballGravityData;
    [SerializeField] ProjectileGravityData[] torpedoBoatShotgunShotGravityData;
    [SerializeField] ProjectileGravityData[] ironcladCannonballGravityData;
    [SerializeField] ProjectileGravityData[] shipXCannonballGravityData;

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

        settingNumber = PlayerPrefs.GetInt("SpeedSetting", 1);

        shipDatas = new List<ShipData[]> { frigateData, torpedoBoatData, ironcladData, shipXData };
        shipMovementDatas = new List<ShipMovementData[]> { frigateMovementData, torpedoBoatMovementData, ironcladMovementData, shipXMovementData };
        shipRigidbodyDatas = new List<RigidbodyData[]> { frigateRigidbodyData, torpedoBoatRigidbodyData, ironcladRigidbodyData, shipXRigidbodyData };  
        aimPointDatas = new List<AimPointData[]> { frigateFrontCannonAimData, torpedoBoatRearCannonAimData, ironcladCannonAimData };                                                                                                                              
        shooterDatas = new List<ShooterData[]> { frigateCannonballShooterData, frigateMineShooterData, torpedoBoatTorpedoShooterData,
            torpedoBoatShotgunData, torpedoBoatBurstCannonData, ironcladCannonballShooterData, ironcladFlamethrowerShooterData,
            shipXCannonShooterData};
        projectileDatas = new List<ProjectileData[]> { frigateCannonballProjectileData, frigateMineProjectileData, 
            torpedoBoatTorpedoProjectileData, torpedoBoatShotgunShotProjectileData, torpedoBoatCannonballProjectileData, 
            ironcladCannonballProjectileData, null, shipXProjectileData };
        projectileRigidbodyDatas = new List<RigidbodyData[]> { frigateCannonballRigidbodyData, frigateMineRigidbodyData, 
            torpedoBoatTorpedoRigidbodyData, torpedoBoatShotgunShotRigidbodyData, torpedoBoatCannonballRigidbodyData,
            ironcladCannonballRigidbodyData, null, shipXCannonballRigidbodyData};
        projectileGravityDatas = new List<ProjectileGravityData[]> { frigateCannonballGravityData, null, null, torpedoBoatShotgunShotGravityData, 
            torpedoBoatCannonballGravityData, ironcladCannonballGravityData, null, shipXCannonballGravityData };
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
