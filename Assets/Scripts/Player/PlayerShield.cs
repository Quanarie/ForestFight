using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private float maxArmor;
    [SerializeField] private float recoverySpeed;
    [SerializeField] private Slider currentArmorSlider;
    [SerializeField] private Slider maxArmorUpgradeSlider;
    [SerializeField] private Slider armorRecoveryUpgradeSlider;

    private float currentArmor;

    private void Start()
    {
        currentArmor = maxArmor;
        currentArmorSlider.value = currentArmor;
        currentArmorSlider.maxValue = maxArmor;
        maxArmorUpgradeSlider.value = maxArmor;
        armorRecoveryUpgradeSlider.value = recoverySpeed;
    }

    private void Update()
    {
        if (currentArmor + Time.deltaTime * recoverySpeed <= maxArmor)
        {
            currentArmor += Time.deltaTime * recoverySpeed;
            currentArmorSlider.value = currentArmor;
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentArmor - damage >= 0)
        {
            currentArmor -= damage;
            currentArmorSlider.value = currentArmor;
        }
        else
        {
            GetComponent<PlayerHealth>().TakeDamage(damage - currentArmor);
        }
    }

    public void OnMaxArmorChange(float newArmor)
    {
        if (newArmor > maxArmor)
        {
            maxArmor = newArmor;
        }
    }

    public void OnArmorRecoveryChange(float newArmorRecovery)
    {
        if (newArmorRecovery > recoverySpeed)
        {
            recoverySpeed = newArmorRecovery;
        }
    }

    public float MaxArmor
    {
        get
        {
            return maxArmor;
        }
        set
        {
            if (value > 0)
            {
                maxArmor = value;
            }
        }
    }

    public float CurrentArmor
    {
        get
        {
            return currentArmor;
        }
        set
        {
            if (value > 0)
            {
                currentArmor = value;
            }
        }
    }

    public float RecoverySpeed
    {
        get
        {
            return recoverySpeed;
        }
        set
        {
            if (value > 0)
            {
                recoverySpeed = value;
            }
        }
    }
}
