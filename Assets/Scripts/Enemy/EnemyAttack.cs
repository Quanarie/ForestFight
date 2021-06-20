using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float rechargeTime;

    private float timeFromPreviousAttack;

    private void Update()
    {
        timeFromPreviousAttack += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerShield _))
        {
            if (timeFromPreviousAttack >= rechargeTime)
            {
                collision.GetComponent<PlayerShield>().TakeDamage(damage);

                collision.GetComponent<Animator>().SetTrigger("damage");

                timeFromPreviousAttack = 0;
            }
        }
    }
}
