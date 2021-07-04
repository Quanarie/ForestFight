using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float rechargeTime;

    private float timeFromPreviousAttack = 0f;

    private void Update()
    {
        timeFromPreviousAttack += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeFromPreviousAttack >= rechargeTime)
        {
            if (collision.TryGetComponent(out PlayerShield _))
            {
                collision.GetComponent<PlayerShield>().TakeDamage(damage);

                collision.GetComponent<Animator>().SetTrigger("damage");

                timeFromPreviousAttack = 0;
            }
        }
    }

    public float GetTimeFromPreviousAttack() => timeFromPreviousAttack;
    public float GetRechargeTime() => rechargeTime;
}
