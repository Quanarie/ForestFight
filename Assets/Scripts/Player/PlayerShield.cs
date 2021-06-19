using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private float maxArmor;

    private float currentArmor;
    private float recoverySpeed = 1;

    private void Start()
    {
        currentArmor = maxArmor;
    }

    private void Update()
    {
        if (currentArmor + Time.deltaTime * recoverySpeed <= maxArmor)
        {
            currentArmor += Time.deltaTime * recoverySpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentArmor - damage >= 0)
        {
            currentArmor -= damage;
        }
        else
        {
            GetComponent<PlayerHealth>().TakeDamage(damage - currentArmor);
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
