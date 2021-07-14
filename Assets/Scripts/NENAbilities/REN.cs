using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REN : MonoBehaviour, AbstractNENAbility
{
    [SerializeField] private float RENRadius;
    [SerializeField] private float RENDanger;

    private const float damageUpgradeCoefficient = 3f;

    public void Activate()
    {
        GetComponent<PlayerAttack>().Damage = GetComponent<PlayerAttack>().Damage * damageUpgradeCoefficient;
    }

    public void Disactivate()
    {
        GetComponent<PlayerAttack>().Damage = GetComponent<PlayerAttack>().Damage / damageUpgradeCoefficient;
    }

    public void OnRENDangerValueChanged(float newValue)
    {
        RENDanger = newValue;
    }

    public float GetDangerRadius() => RENRadius;
    public float GetDanger() => RENDanger;
}
