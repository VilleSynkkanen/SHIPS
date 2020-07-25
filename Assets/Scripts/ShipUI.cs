using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipUI : MonoBehaviour
{
    [SerializeField] Image negativeThrottle;
    [SerializeField] Image positiveThrottle;
    [SerializeField] Image negativeSteering;
    [SerializeField] Image positiveSteering;
    [SerializeField] Image[] segmentHealth;
    [SerializeField] Image totalHealth;
    [SerializeField] Image[] segmentImages;
    [SerializeField] TextMeshProUGUI[] segmentTexts;
    [SerializeField] Color undamaged;
    [SerializeField] Color fullyDamaged;
    [SerializeField] Image[] shotCooldownImages;
    [SerializeField] bool[] useFills;
    [SerializeField] Color throttlePlus;
    [SerializeField] Color throttleUpZero;
    [SerializeField] Color throttleDownZero;
    [SerializeField] Color throttleMinus;
    [SerializeField] Color steeringZero;
    [SerializeField] Color steeringMax;

    ShipMovement movement;
    ShipDamage damage;
    ShipShooterManager shooter;
    
    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        damage = GetComponent<ShipDamage>();
        shooter = GetComponent<ShipShooterManager>();
        positiveThrottle.fillAmount = 0;
        negativeThrottle.fillAmount = 0;
        positiveSteering.fillAmount = 0;
        negativeSteering.fillAmount = 0;
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        float steering = movement.steering;
        float throttle = movement.throttle;

        if(throttle >= 0)
        {
            positiveThrottle.fillAmount = throttle;
            positiveThrottle.color = Color.Lerp(throttleUpZero, throttlePlus, throttle);
            negativeThrottle.fillAmount = 0;
        }
        else
        {
            negativeThrottle.fillAmount = -throttle;
            negativeThrottle.color = Color.Lerp(throttleDownZero, throttleMinus, -throttle);
            positiveThrottle.fillAmount = 0;
        }

        if (steering >= 0)
        {
            positiveSteering.fillAmount = steering;
            positiveSteering.color = Color.Lerp(steeringZero, steeringMax, steering);
            negativeSteering.fillAmount = 0;
        }
        else
        {
            negativeSteering.fillAmount = -steering;
            negativeSteering.color = Color.Lerp(steeringZero, steeringMax, -steering);
            positiveSteering.fillAmount = 0;
        }

        for(int i = 0; i < shotCooldownImages.Length; i++)
        {
            if(useFills[i])
            {
                if(shooter.Shooters[i].Data.LimitedAmmo && shooter.Shooters[i].ammoLeft <= 0)
                {
                    shotCooldownImages[i].fillAmount = 1;
                }
                else
                {
                    shotCooldownImages[i].fillAmount = shooter.Shooters[i].cooldownLeft / shooter.Shooters[i].Data.ShotCooldown;
                }
            }
        }
    }

    public void UpdateHealthbars(float f = 0, SegmentType s = SegmentType.Middle)    // parameters not used
    {
        for (int i = 0; i < segmentHealth.Length; i++)
        {
            segmentHealth[i].fillAmount = damage.SegmentHealth[i];
            segmentImages[i].color = Color.Lerp(fullyDamaged, undamaged, damage.SegmentHealth[i]);
            segmentTexts[i].text = Mathf.RoundToInt(100 * movement.CalculateDamageEffects(damage.SegmentHealth[i])).ToString() + "%";
        }

        totalHealth.fillAmount = damage.hp / damage.MaxHp;
    }
}