using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIEasy : MonoBehaviour
{
    // Enemy goes away while recharging it's ability

    private float timeFromPreviousAttack;
    private float rechargeTime;
    private EnemyMovement enemyMovement;
    private EnemyAttack enemyAttack;

    private void Start()
    {
        rechargeTime = GetComponent<EnemyAttack>().GetRechargeTime();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Update()
    {
        timeFromPreviousAttack = enemyAttack.GetTimeFromPreviousAttack();

        if (timeFromPreviousAttack < rechargeTime)
        {
            enemyMovement.SetDirection(false);
        }
        else
        {
            enemyMovement.SetDirection(true);
        }
    }
}
