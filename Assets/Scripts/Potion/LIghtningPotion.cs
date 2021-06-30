using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtningPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private float toDamage;
    [SerializeField] private float attackRadius;

    private Vector3 playerPosition;
    private GameObject[] enemies;

    public void Use()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearestEnemy = null;
        float shortestDistance = attackRadius;
        for (int i = 0; i < enemies.Length; i++)
        {
            float distanceBtwPlayerAndEnemy = Vector3.Distance(playerPosition, enemies[i].transform.position);
            if (distanceBtwPlayerAndEnemy < shortestDistance)
            {
                nearestEnemy = enemies[i];
                shortestDistance = Vector3.Distance(playerPosition, enemies[i].transform.position);
            }
        }

        //attack
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<EnemyHealth>().TakeDamage(toDamage);
        }
        Destroy(gameObject);
    }
}
