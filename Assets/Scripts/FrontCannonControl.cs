using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCannonControl : MonoBehaviour
{
    PlayerInput input;
    Vector3 currentAngles;
    [SerializeField] Transform cannon;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxAngle;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        currentAngles = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        RotateCannon();
    }

    void ReadInput()
    {
        currentAngles.z -= input.aim * rotationSpeed * Time.deltaTime;
        currentAngles.z = Mathf.Clamp(currentAngles.z, -maxAngle, maxAngle);
    }

    void RotateCannon()
    {
        Vector3 shipRotation = new Vector3(0, 0, transform.eulerAngles.z);
        cannon.eulerAngles = currentAngles + shipRotation;
    }
}