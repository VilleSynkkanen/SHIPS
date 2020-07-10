using UnityEngine;

public class AimControl : MonoBehaviour
{
    PlayerControlInput input;
    ShipShooterManager shooter;
    Vector3[] currentAngles;
    [SerializeField] Transform[] aimPoints;
    AimPointData data;
    [SerializeField] Vector3[] baseRotations;
    [SerializeField] AimPointType type;
    [SerializeField] int[] aimDirections;

    void Awake()
    {
        data = GameSettings.Instance.GetAimPointData(type);
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
        bool canAim = false;
        for (int i = 0; i < aimPoints.Length; i++)
        {
            // can be aimed if at least one shooter has not shot
            if (shooter.AimableShooters[i].cooldownLeft <= 0)
            {
                canAim = true;
            }
        }

        if (!canAim)
            return;

        for (int i = 0; i < aimPoints.Length; i++)
        {
            currentAngles[i].z -= aimDirections[i] * input.aim * data.RotationSpeed * Time.deltaTime;
            currentAngles[i].z = Mathf.Clamp(currentAngles[i].z, -data.MaxAngle, data.MaxAngle);
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