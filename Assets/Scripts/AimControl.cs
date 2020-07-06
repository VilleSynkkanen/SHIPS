using UnityEngine;

public class AimControl : MonoBehaviour
{
    PlayerControlInput input;
    ShipShooterManager shooter;
    Vector3[] currentAngles;
    [SerializeField] Transform[] aimPoints;
    AimPointData[] data;
    [SerializeField] Vector3[] baseRotations;
    [SerializeField] AimPointType[] type;

    void Awake()
    {
        data = new AimPointData[type.Length];
        for(int i = 0; i < type.Length; i++)
        {
            data[i] = GameSettings.Instance.GetAimPointData(type[i]);
        }
        shooter = GetComponent<ShipShooterManager>();
        input = GetComponent<PlayerControlInput>();
        currentAngles = new Vector3[aimPoints.Length];
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        RotatePoints();
    }

    void ReadInput()
    {
        for (int i = 0; i < aimPoints.Length; i++)
        {
            if(shooter.AimableShooters[i].cooldownLeft <= 0)
            {
                currentAngles[i].z -= input.Aim[i] * data[i].RotationSpeed * Time.deltaTime;
                currentAngles[i].z = Mathf.Clamp(currentAngles[i].z, -data[i].MaxAngle, data[i].MaxAngle);
            }
        }    
    }

    void RotatePoints()
    {
        for(int i = 0; i < aimPoints.Length; i++)
        {
            Vector3 shipRotation = new Vector3(0, 0, transform.eulerAngles.z);
            aimPoints[i].eulerAngles = currentAngles[i] + shipRotation + baseRotations[i];
        }
    }
}