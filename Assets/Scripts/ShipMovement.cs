using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    ShipMovementData data;

    float currentMoveSpeed;
    float currentTurnSpeed;
    float currentSteeringSpeed;
    float currentThrottleSpeed;

    public float throttle { get; private set; }  //[-1, 1]
    public float steering { get; private set; }  //[-1, 1]

    Rigidbody2D rb;
    public PlayerControlInput input { get; private set; }
    public PlayerInput playerInput { get; private set; }

    void Awake()
    {
        data = GameSettings.Instance.ShipMovementData;
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerControlInput>();
        playerInput = GetComponent<PlayerInput>();

        currentMoveSpeed = data.moveSpeed;
        currentTurnSpeed = data.turnSpeed;
        currentSteeringSpeed = data.steeringSpeed;
        currentThrottleSpeed = data.throttleSpeed;
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        float multiplier = 1;
        if (throttle < 0)
            multiplier = data.reverseSpeed;

        rb.AddRelativeForce(Vector2.up * multiplier * currentMoveSpeed * throttle * Time.fixedDeltaTime);
        rb.AddTorque(-currentTurnSpeed * steering * Time.fixedDeltaTime);
    }

    public void SetControlsToZero()
    {
        throttle = 0;
        steering = 0;
    }
    
    void ReadInput()
    {
        steering += input.horizontal * currentSteeringSpeed * Time.deltaTime;
        steering = Mathf.Clamp(steering, -1, 1);

        throttle += input.vertical * currentThrottleSpeed * Time.deltaTime;
        throttle = Mathf.Clamp(throttle, -1, 1);
    }

    public void SegmentDamage(float health, SegmentType segment)
    {
        float effect = CalculateDamageEffects(health);
        if (segment == SegmentType.Front)
        {
            currentMoveSpeed = data.moveSpeed * effect;
        }
        else if (segment == SegmentType.Middle)
        {
            currentSteeringSpeed = data.steeringSpeed * effect;
            currentThrottleSpeed = data.throttleSpeed * effect;
        }
        else if (segment == SegmentType.Back)
        {
            currentTurnSpeed = data.turnSpeed * effect;
        }
    }

    public float CalculateDamageEffects(float health)
    {
        return data.damageAngleCoefficient * health + data.maxDamageEffect;
    }
}