using System.Collections;
using UnityEngine;
using UnityEngine.Events;



public class ShipLayMine : MonoBehaviour
{
    PlayerControlInput input;
    [SerializeField] AudioSource soundEffect;
    ShipUI ui;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotLocation;
    MineData data;

    bool onCooldown;
    public float cooldownLeft { get; private set; }

    public int mines { get; private set; }
    public float ShotCooldown { get => data.shotCooldown; }

    public event UnityAction mined = delegate { };

    private void Awake()
    {
        data = GameSettings.Instance.MineData;
        input = GetComponent<PlayerControlInput>();
        ui = GetComponent<ShipUI>();
        mines = data.startingMines;
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
        soundEffect.Play();
        onCooldown = true;
        GameObject mine = Instantiate(projectile, shotLocation.position, shotLocation.rotation);
        mine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * data.shotForce);
        StartCoroutine(ActivateCollider(mine.GetComponent<Collider2D>()));
        cooldownLeft = data.shotCooldown;
        mines--;
    }

    IEnumerator ActivateCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(data.activationDelay);
        collider.enabled = true;
    }

    void OnDestroy()
    {
        mined += ui.UpdateMines;
    }


}