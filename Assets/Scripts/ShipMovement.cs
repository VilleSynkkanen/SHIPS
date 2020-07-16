using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] ShipType type;  
    ShipMovementData data;
    Rigidbody2D rb;

    float currentMoveSpeed;
    float currentTurnSpeed;
    float currentSteeringSpeed;
    float currentThrottleSpeed;
    float moveMultiplier;
    float turnMultiplier;
    float turningCoefficient;

    public float throttle { get; private set; }  //[-1, 1]
    public float steering { get; private set; }  //[-1, 1]

    public PlayerControlInput input { get; private set; }
    public PlayerInput playerInput { get; private set; }

    void Awake()
    {
        data = GameSettings.Instance.GetShipMovementData(type);
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerControlInput>();
        playerInput = GetComponent<PlayerInput>();
        ResetShipDamage();
    }

    public void ResetShipDamage()
    {
        currentMoveSpeed = data.MoveSpeed;
        currentTurnSpeed = data.TurnSpeed;
        currentSteeringSpeed = data.SteeringSpeed;
        currentThrottleSpeed = data.ThrottleSpeed;
        moveMultiplier = 1;
        turnMultiplier = 1;
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
        turningCoefficient = 1;
        if (rb.velocity.magnitude < data.TurningPenaltyTreshold)
        {
            turningCoefficient = (1 - data.MaxTurningPenalty) * rb.velocity.magnitude / data.TurningPenaltyTreshold + data.MaxTurningPenalty;
        }
        
        // makes reversing invert turning controls (experimental)
        if (Vector3.Dot(rb.velocity, transform.up) < 0)
            turningCoefficient *= -1;

        rb.AddRelativeForce(Vector2.up * multiplier * currentMoveSpeed * moveMultiplier * throttle * Time.fixedDeltaTime);
        rb.AddTorque(-currentTurnSpeed * turnMultiplier * steering * turningCoefficient * Time.fixedDeltaTime);
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

    public void SlowEffect(float move, float turn)
    {
        moveMultiplier -= move;
        turnMultiplier -= turn;
    }

    public void EndSlowEffect(float move, float turn)
    {
        moveMultiplier += move;
        turnMultiplier += turn;
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