using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackDistance;
    [SerializeField] private float damage;
    [SerializeField] private float rechargeTime;
    [SerializeField] private LayerMask attackableObjects;

    private Animator animator;
    private float timeFromPreviousAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack() 
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, attackableObjects);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        animator.SetTrigger("attack");


        if (timeFromPreviousAttack >= rechargeTime)
        {
            
        }
        else
        {
            timeFromPreviousAttack += Time.deltaTime;
        }
    }
}
