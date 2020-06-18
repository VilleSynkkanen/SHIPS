using UnityEngine;

public class FrontCannonControl : MonoBehaviour
{
    PlayerControlInput input;
    ShipShooter shooter;
    Vector3 currentAngles;
    [SerializeField] Transform cannon;
    [SerializeField] FrontCannonData data;

    void Awake()
    {
        input = GetComponent<PlayerControlInput>();
        shooter = GetComponent<ShipShooter>();
        currentAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if(!shooter.ShotInfo[2].onCooldown)
            ReadInput();
    }

    void FixedUpdate()
    {
        RotateCannon();
    }

    void ReadInput()
    {
        currentAngles.z -= input.aim * data.rotationSpeed * Time.deltaTime;
        currentAngles.z = Mathf.Clamp(currentAngles.z, -data.maxAngle, data.maxAngle);
    }

    void RotateCannon()
    {
        Vector3 shipRotation = new Vector3(0, 0, transform.eulerAngles.z);
        cannon.eulerAngles = currentAngles + shipRotation;
    }
}