using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEN : MonoBehaviour, AbstractNENAbility
{
    public void Activate()
    {
        GetComponent<PlayerShield>().MaxArmor = GetComponent<PlayerShield>().MaxArmor * 1.5f;
        GetComponent<PlayerShield>().RecoverySpeed = GetComponent<PlayerShield>().RecoverySpeed * 1.5f;
    }

    public void Disactivate()
    {
        GetComponent<PlayerShield>().MaxArmor = GetComponent<PlayerShield>().MaxArmor / 1.5f;
        GetComponent<PlayerShield>().RecoverySpeed = GetComponent<PlayerShield>().RecoverySpeed / 1.5f;
    }
}
