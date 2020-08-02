using UnityEngine;
using UnityEngine.Events;

public enum SegmentType { Front, Middle, Back }

public class ShipSegment : MonoBehaviour, ICollision
{
    [SerializeField] SegmentType type;
    [SerializeField] Rigidbody2D rb;   
    [SerializeField] ShipDamage ship;
    [SerializeField] AudioSource terrainDamage;
    [SerializeField] float volumeSpeedMultiplier;

    int i;
    public ShipData data { get; private set; }
    public float hp { get; private set; }
    public int MaxHp { get => data.SegmentHp[i]; }
    public Rigidbody2D Rb { get => rb; }
    public ShipDamage Ship { get => ship; }

    public event UnityAction<float, SegmentType> damageTaken = delegate { };

    void Awake()
    {
        data = GameSettings.Instance.GetShipData(Ship.Type);
        i = (int)type;
        hp = MaxHp;
        damageTaken += Ship.TakeDamage;
    }

    void Update()
    {
        terrainDamage.volume = volumeSpeedMultiplier * rb.velocity.magnitude;
    }

    public void ResetSegmentHealth()
    {
        hp = MaxHp;
        StopTerrainDamage();
    }
    
    public void Collision(ProjectileCollision collider)
    {
        Vector2 velocity = collider.rb.velocity;
        Vector2 position = new Vector2(collider.transform.position.x, collider.transform.position.y);
        Rb.AddExplosionForce(collider.ExplosionForce, position);
        TakeDamage(collider.CalculateDamage(velocity));
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp < 0)
            hp = 0;
        damageTaken(amount, type);
    }

    public void PlayTerrainDamage()
    {
        terrainDamage.Play();
    }

    public void StopTerrainDamage()
    {
        terrainDamage.Stop();
    }


    void OnDestroy()
    {
        damageTaken -= Ship.TakeDamage;
    }
}