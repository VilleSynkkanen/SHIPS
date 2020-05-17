using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Side {Left, Right, Front};

struct ShotInfo
{
    public bool input;
    public bool onCooldown;
    public float cooldownLeft;
    public float shotCharge;
    public float cooldown;
}

public class ShipShooter : MonoBehaviour
{
    PlayerInput input;
    ShotEffects effects;
    Rigidbody2D rb;
    ShipUI ui;

    ShotInfo[] shotInfo = new ShotInfo[3];

    [SerializeField] float chargeSpeed;
    [SerializeField] float minimumCharge;
    [SerializeField] float sideShotCooldown;
    [SerializeField] float forwardShotCooldown;
    [SerializeField] float shotForce;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float rotationVariation;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform[] leftLocations;
    [SerializeField] Transform[] rightLocations;
    [SerializeField] Transform[] forwardLocations;

    string tag;     //used for identifying colliding projectiles

    internal ShotInfo[] ShotInfo { get => shotInfo; }
    public float SideShotCooldown { get => sideShotCooldown; }

    public event UnityAction<Side> shot = delegate { };

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        effects = GetComponent<ShotEffects>();
        ui = GetComponent<ShipUI>();

        for(int i = 0; i < shotInfo.Length; i++)
            shotInfo[i] = new ShotInfo();

        shotInfo[0].cooldown = sideShotCooldown;
        shotInfo[1].cooldown = sideShotCooldown;
        shotInfo[2].cooldown = forwardShotCooldown;

        tag = gameObject.tag;
        shot += effects.Effect;
        shot += ui.ShotCannon;
    }

    void Update()
    {
        ReadInput();
        ChargeShot();
        UpdateCooldowns();
    }

    void ReadInput()
    {
        shotInfo[0].input = input.shootLeft;
        shotInfo[1].input = input.shootRight;
        shotInfo[2].input = input.shootForward;
    }

    IEnumerator ShotCooldown(int index)
    {
        shotInfo[index].onCooldown = true;
        yield return new WaitForSeconds(shotInfo[index].cooldown);
        shotInfo[index].onCooldown = false;
    }

    void ChargeShot()
    {
        for(int i = 0; i < shotInfo.Length; i++)
        {
            if(shotInfo[i].input && !shotInfo[i].onCooldown)
            {
                shotInfo[i].shotCharge += chargeSpeed * Time.deltaTime;
                if (shotInfo[i].shotCharge >= 1)
                {
                    Shoot((Side)i, 1);
                    ShotInfo[i].shotCharge = 0;
                    shotInfo[i].cooldownLeft = shotInfo[i].cooldown;
                    StartCoroutine(ShotCooldown(i));
                }
            }
            else if(!shotInfo[i].input && !shotInfo[i].onCooldown && shotInfo[i].shotCharge > minimumCharge)
            {
                Shoot((Side)i, shotInfo[i].shotCharge);
                shotInfo[i].shotCharge = 0;
                shotInfo[i].cooldownLeft = shotInfo[i].cooldown;
                StartCoroutine(ShotCooldown(i));
            }
            else
            {
                shotInfo[i].shotCharge = 0;
            }
        }
    }

    void Shoot(Side side, float charge)
    {
        Transform[] shotLocations;
        Vector2 recoil;
        if (side == Side.Left)
        {
            shotLocations = leftLocations;
            recoil = Vector2.right;
        }
        else if(side == Side.Right)
        {
            shotLocations = rightLocations;
            recoil = Vector2.left;
        }
        else
        {
            shotLocations = forwardLocations;
            recoil = Vector2.down;
        }

        foreach (Transform location in shotLocations)
        {
            float forceMultiplier = Random.Range(minForce, maxForce);
            float rotation = Random.Range(-rotationVariation, rotationVariation);

            GameObject clone = Instantiate(projectile, location.position, location.rotation);
            clone.tag = tag;
            Rigidbody2D ball = clone.GetComponent<Rigidbody2D>();
            ball.rotation += rotation;
            ball.AddRelativeForce(Vector2.up * shotForce * charge * forceMultiplier);
            rb.AddRelativeForce(recoil * shotForce * charge * forceMultiplier);
        }
        
        shot(side);
    }

    void UpdateCooldowns()
    {
        for(int i = 0; i < shotInfo.Length; i++)
        {
            if(shotInfo[i].onCooldown)
            {
                shotInfo[i].cooldownLeft -= Time.deltaTime;
            }
        }
    }

    private void OnDisable()
    {
        shot -= effects.Effect;
        shot -= ui.ShotCannon;
    }
}