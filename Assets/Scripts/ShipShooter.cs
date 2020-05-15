using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Side {Left, Right};

struct ShotInfo
{
    public bool input;
    public bool onCooldown;
    public float shotCharge;
}

public class ShipShooter : MonoBehaviour
{
    PlayerInput input;
    ShotEffects effects;
    Rigidbody2D rb;

    ShotInfo[] shotInfo = new ShotInfo[2];

    [SerializeField] float chargeSpeed;
    [SerializeField] float minimumCharge;
    [SerializeField] float shotCooldown;
    [SerializeField] float shotForce;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float rotationVariation;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform[] leftLocations;
    [SerializeField] Transform[] rightLocations;

    string tag;     //used for identifying colliding projectiles

    public event UnityAction<Side> shot = delegate { };

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        effects = GetComponent<ShotEffects>();

        for(int i = 0; i <shotInfo.Length; i++)
            shotInfo[i] = new ShotInfo();

        tag = gameObject.tag;
        shot += effects.Effect;
    }

    void Update()
    {
        ReadInput();
        ChargeShot();
    }

    void ReadInput()
    {
        shotInfo[0].input = input.shootLeft;
        shotInfo[1].input = input.shootRight;
    }

    IEnumerator ShotCooldown(int index)
    {
        shotInfo[index].onCooldown = true;
        yield return new WaitForSeconds(shotCooldown);
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
                    shotInfo[i].shotCharge = 0;
                    StartCoroutine(ShotCooldown(i));
                }
            }
            else if(!shotInfo[i].input && !shotInfo[i].onCooldown && shotInfo[i].shotCharge > minimumCharge)
            {
                Shoot((Side)i, shotInfo[i].shotCharge);
                shotInfo[i].shotCharge = 0;
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
        else
        {
            shotLocations = rightLocations;
            recoil = Vector2.left;
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

    private void OnDisable()
    {
        shot -= effects.Effect;
    }
}
