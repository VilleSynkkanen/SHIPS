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
    [SerializeField] GameObject[] arrows;
    [SerializeField] Image[] arrowFills;
    
    [SerializeField] TextMeshProUGUI mineText;
    [SerializeField] Image mineCooldownImage;

    ShipMovement movement;
    ShipDamage damage;
    ShipShooter shooter;
    ShipLayMine mines;
    
    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        damage = GetComponent<ShipDamage>();
        shooter = GetComponent<ShipShooter>();
        mines = GetComponent<ShipLayMine>();
        positiveThrottle.fillAmount = 0;
        negativeThrottle.fillAmount = 0;
        positiveSteering.fillAmount = 0;
        negativeSteering.fillAmount = 0;
        for(int i = 0; i < arrowFills.Length; i++)
            arrowFills[i].fillAmount = 0;
    }

    private void Start()
    {
        UpdateMines();
    }

    public void UpdateUI()
    {
        float steering = movement.steering;
        float throttle = movement.throttle;

        if(throttle >= 0)
        {
            positiveThrottle.fillAmount = throttle;
            negativeThrottle.fillAmount = 0;
        }
        else
        {
            negativeThrottle.fillAmount = -throttle;
            positiveThrottle.fillAmount = 0;
        }

        if (steering >= 0)
        {
            positiveSteering.fillAmount = steering;
            negativeSteering.fillAmount = 0;
        }
        else
        {
            negativeSteering.fillAmount = -steering;
            positiveSteering.fillAmount = 0;
        }

        for(int i = 0; i < shotCooldownImages.Length; i++)
        {
            shotCooldownImages[i].fillAmount = shooter.ShotInfo[i].cooldownLeft / shooter.ShotInfo[i].cooldown;
            arrowFills[i].fillAmount = shooter.ShotInfo[i].shotCharge;
            if (!shooter.ShotInfo[i].onCooldown)
            {
                arrows[i].SetActive(true);
            }
        }

        if (mines.mines != 0)
            mineCooldownImage.fillAmount = mines.cooldownLeft / mines.ShotCooldown;
    }

    public void UpdateHealthbars(float f, SegmentType s)    // parameters not used
    {
        for (int i = 0; i < segmentHealth.Length; i++)
        {
            segmentHealth[i].fillAmount = damage.SegmentHealth[i];
            segmentImages[i].color = Color.Lerp(fullyDamaged, undamaged, damage.SegmentHealth[i]);
            segmentTexts[i].text = Mathf.RoundToInt(100 * movement.CalculateDamageEffects(damage.SegmentHealth[i])).ToString() + "%";
        }

        totalHealth.fillAmount = damage.hp / damage.MaxHp;
    }

    public void ShotCannon(Side side)
    {
        arrows[(int)side].SetActive(false);
    }

    public void UpdateMines()
    {
        mineText.text = mines.mines.ToString();
        if(mines.mines == 0)
        {
            mineCooldownImage.fillAmount = 1;
        }
    }
}