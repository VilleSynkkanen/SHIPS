using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ShipLayMine : MonoBehaviour
{
    PlayerInput input;
    ShipUI ui;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotLocation;
    [SerializeField] float shotForce;
    [SerializeField] float shotCooldown;
    [SerializeField] int startingMines;
    [SerializeField] float activationDelay;

    bool onCooldown;
    public float cooldownLeft { get; private set; }

    public int mines { get; private set; }
    public float ShotCooldown { get => shotCooldown; }

    public event UnityAction mined = delegate { };

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        ui = GetComponent<ShipUI>();
        mines = startingMines;
        onCooldown = false;
        cooldownLeft = 0;
        mined += ui.UpdateMines;
    }

    void Update()
    {
        if(input.mine && !onCooldown && mines > 0)
        {
            LayMine();
            mined();
        }

        if(onCooldown)
        {
            cooldownLeft -= Time.deltaTime;
            if(cooldownLeft <= 0)
            {
                onCooldown = false;
            }
        }
    }

    void LayMine()
    {
        onCooldown = true;
        GameObject mine = Instantiate(projectile, shotLocation.position, shotLocation.rotation);
        mine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * shotForce);
        StartCoroutine(ActivateCollider(mine.GetComponent<Collider2D>()));
        cooldownLeft = shotCooldown;
        mines--;
    }

    IEnumerator ActivateCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(activationDelay);
        collider.enabled = true;
    }

    void OnDisable()
    {
        mined += ui.UpdateMines;
    }


}