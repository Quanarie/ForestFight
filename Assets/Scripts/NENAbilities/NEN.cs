using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NEN : MonoBehaviour, AbstractNENAbility
{
    [SerializeField] private Slider currentArmorSlider;

    private const float armorUpgradeCoefficient = 1.5f;
    private const float armorRecoveryUpgradeCoefficient = 1.5f;

    public void Activate()
    {
        GetComponent<PlayerShield>().MaxArmor = GetComponent<PlayerShield>().MaxArmor * armorUpgradeCoefficient;
        GetComponent<PlayerShield>().RecoverySpeed = GetComponent<PlayerShield>().RecoverySpeed * armorRecoveryUpgradeCoefficient;

        currentArmorSlider.maxValue = GetComponent<PlayerShield>().MaxArmor;
    }

    public void Disactivate()
    {
        GetComponent<PlayerShield>().MaxArmor = GetComponent<PlayerShield>().MaxArmor / armorUpgradeCoefficient;
        if (GetComponent<PlayerShield>().CurrentArmor > GetComponent<PlayerShield>().MaxArmor)
        {
            GetComponent<PlayerShield>().CurrentArmor = GetComponent<PlayerShield>().MaxArmor;
        }
        GetComponent<PlayerShield>().RecoverySpeed = GetComponent<PlayerShield>().RecoverySpeed / armorRecoveryUpgradeCoefficient;

        currentArmorSlider.maxValue = GetComponent<PlayerShield>().MaxArmor;
    }
}
