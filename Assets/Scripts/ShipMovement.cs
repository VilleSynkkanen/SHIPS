using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float steeringSpeed;
    [SerializeField] float throttleSpeed;
    [SerializeField] float reverseSpeed;

    [SerializeField] float damageAngleCoefficient;
    [SerializeField] float maxDamageEfeect;

    float currentMoveSpeed;
    float currentTurnSpeed;
    float currentSteeringSpeed;
    float currentThrottleSpeed;

    public float throttle { get; private set; }  //[-1, 1]
    public float steering { get; private set; }  //[-1, 1]

    Rigidbody2D rb;
    public PlayerControlInput input { get; private set; }
    public PlayerInput playerInput { get; private set; }
    ShipUI ui;

    public event UnityAction inputChanged = delegate { };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerControlInput>();
        playerInput = GetComponent<PlayerInput>();
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
        float multiplier = 1;
        if (throttle < 0)
            multiplier = reverseSpeed;

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

        inputChanged();
    }

    public void SegmentDamage(float health, SegmentType segment)
    {
        float effect = CalculateDamageEffects(health);
        if (segment == SegmentType.Front)
        {
            currentMoveSpeed = moveSpeed * effect;
        }
        else if (segment == SegmentType.Middle)
        {
            currentSteeringSpeed = steeringSpeed * effect;
            currentThrottleSpeed = throttleSpeed * effect;
        }
        else if (segment == SegmentType.Back)
        {
            currentTurnSpeed = turnSpeed * effect;
        }
    }

    public float CalculateDamageEffects(float health)
    {
        return damageAngleCoefficient * health + maxDamageEfeect;
    }

    void OnDisable()
    {
        inputChanged -= ui.UpdateUI;
    }

    void OnDestroy()
    {
        inputChanged -= ui.UpdateUI;
    }
}