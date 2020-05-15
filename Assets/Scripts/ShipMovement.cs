using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float steeringSpeed;
    [SerializeField] float throttleSpeed;

    float currentMoveSpeed;
    float currentTurnSpeed;
    float currentSteeringSpeed;
    float currentThrottleSpeed;

    public float throttle { get; private set; }  //[-1, 1]
    public float steering { get; private set; }  //[-1, 1]

    Rigidbody2D rb;
    PlayerInput input;
    ShipUI ui;

    public event UnityAction inputChanged = delegate { };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        ui = GetComponent<ShipUI>();
        inputChanged += ui.UpdateUI;

        currentMoveSpeed = moveSpeed;
        currentTurnSpeed = turnSpeed;
        currentSteeringSpeed = steeringSpeed;
        currentThrottleSpeed = throttleSpeed;
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * currentMoveSpeed * throttle * Time.fixedDeltaTime);
        rb.AddTorque(-currentTurnSpeed * steering * Time.fixedDeltaTime);
    }

    void ReadInput()
    {
        steering += input.horizontal * currentSteeringSpeed * Time.deltaTime;
        steering = Mathf.Clamp(steering, -1, 1);

        throttle += input.vertical * currentThrottleSpeed * Time.deltaTime;
        throttle = Mathf.Clamp(throttle, -1, 1);

        inputChanged();
    }

    public void SegmentDamage(float health, SegmentType segment)
    {
        health = Mathf.Sqrt(health);
        if (segment == SegmentType.Front)
        {
            currentMoveSpeed = moveSpeed * health;
        }
        else if (segment == SegmentType.Middle)
        {
            currentSteeringSpeed = steeringSpeed * health;
            currentThrottleSpeed = throttleSpeed * health;
        }
        else if (segment == SegmentType.Back)
        {
            currentTurnSpeed = turnSpeed * health;
        }
    }

    void OnDisable()
    {
        inputChanged -= ui.UpdateUI;
    }
}

