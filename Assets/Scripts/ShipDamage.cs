using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipDamage : MonoBehaviour
{
    [SerializeField] ShipSegment[] segments;
    [SerializeField] GameObject shipExplosion;

    [SerializeField] int maxHp;
    public float hp { get; private set; }

    float[] segmentHealth = new float[3];

    //front hp: speed
    //middle hp: control speed
    //rear hp: turning

    ShipMovement movement;
    ShipUI ui;

    public float[] SegmentHealth { get => segmentHealth; }
    public int MaxHp { get => maxHp; }

    public event UnityAction<float, SegmentType> segmentDamage = delegate { };

    public static event UnityAction<GameObject> destroyed = delegate { };

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        ui = GetComponent<ShipUI>();
        segmentDamage += movement.SegmentDamage;
        segmentDamage += ui.UpdateHealthbars;
        hp = maxHp;
        for (int i = 0; i < segmentHealth.Length; i++)
            SegmentHealth[i] = 1f;
    }

    public void TakeDamage(float amount, SegmentType segment)
    {
        hp -= amount;
        int i = (int)segment;
        segmentHealth[i] = segments[i].hp / segments[i].MaxHp;
        segmentDamage(segmentHealth[i], segment);

        if(hp <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Instantiate(shipExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
        destroyed(gameObject);
    }

    void OnDisable()
    {
        segmentDamage -= movement.SegmentDamage;
        segmentDamage -= ui.UpdateHealthbars;
    }
}