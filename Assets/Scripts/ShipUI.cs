using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUI : MonoBehaviour
{
    [SerializeField] Slider steering;
    [SerializeField] Slider throttle;
    
    ShipMovement movement;
    
    void Awake()
    {
        movement = GetComponent<ShipMovement>();
    }

    public void UpdateUI()
    {
        steering.value = movement.steering;
        throttle.value = movement.throttle;
    }
}
