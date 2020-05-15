using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipDamage : MonoBehaviour
{
    [SerializeField] ShipSegment[] segments;
    
    [SerializeField] int maxHp;
    float hp;

    float[] segmentHealth = new float[3];

    //front hp: speed
    //middle hp: control speed
    //rear hp: turning

    ShipMovement movement;
    public event UnityAction<float, SegmentType> segmentDamage = delegate { };

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        segmentDamage += movement.SegmentDamage;
        hp = maxHp;
        for (int i = 0; i < segmentHealth.Length; i++)
            segmentHealth[i] = 1f;
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
        Destroy(gameObject);
    }

    void OnDisable()
    {
        segmentDamage -= movement.SegmentDamage;
    }
}
