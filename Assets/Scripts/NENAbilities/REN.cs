using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REN : MonoBehaviour, AbstractNENAbility
{
    private const float damageUpgradeCoefficient = 3f;

    public void Activate()
    {
        GetComponent<PlayerAttack>().Damage = GetComponent<PlayerAttack>().Damage * damageUpgradeCoefficient;
    }

    public void Disactivate()
    {
        GetComponent<PlayerAttack>().Damage = GetComponent<PlayerAttack>().Damage / damageUpgradeCoefficient;
    }
}
