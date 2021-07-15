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

    public float percentOfVampireHeal { get; set; }
    public bool isVampiring { get; set; }

    private Animator animator;
    private float timeFromPreviousAttack = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isVampiring = false;
    }
    private void Update()
    {
        timeFromPreviousAttack += Time.deltaTime;
    }

    public void Attack() 
    {
        if (timeFromPreviousAttack >= rechargeTime)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, attackableObjects);
            if (enemies.Length > 0)
            {
                enemies[0].GetComponent<EnemyHealth>().TakeDamage(damage);
                if (isVampiring) GetComponent<PlayerHealth>().Heal(damage * percentOfVampireHeal);
            }

            animator.SetTrigger("attack");

            timeFromPreviousAttack = 0f;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            if (value > 0)
            {
                damage = value;
            }
        }
    }

    public float RechargeTime
    {
        get
        {
            return rechargeTime;
        }
        set
        {
            rechargeTime = value;
        }
    }
}
