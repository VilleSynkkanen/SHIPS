using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] ShipType type;
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
        data = GameSettings.Instance.GetShipMovementData(type);
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerControlInput>();
        playerInput = GetComponent<PlayerInput>();

        currentMoveSpeed = data.MoveSpeed;
        currentTurnSpeed = data.TurnSpeed;
        currentSteeringSpeed = data.SteeringSpeed;
        currentThrottleSpeed = data.ThrottleSpeed;
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        float multiplier = 1;
        if (throttle < 0)
            multiplier = data.ReverseSpeed;

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
            currentMoveSpeed = data.MoveSpeed * effect;
        }
        else if (segment == SegmentType.Middle)
        {
            currentSteeringSpeed = data.SteeringSpeed * effect;
            currentThrottleSpeed = data.ThrottleSpeed * effect;
        }
        else if (segment == SegmentType.Back)
        {
            currentTurnSpeed = data.TurnSpeed * effect;
        }
    }

    public float CalculateDamageEffects(float health)
    {
        return data.DamageAngleCoefficient * health + data.MaxDamageEffect;
    }
}