using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtningPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject lightning;
    [SerializeField] private float toDamage;
    [SerializeField] private float attackRadius;

    private Vector3 playerPosition;
    private GameObject[] enemies;
    private float halfSpriteOfLightning;

    private void Start()
    {
        halfSpriteOfLightning = lightning.GetComponent<SpriteRenderer>().sprite.rect.height / 2;
        halfSpriteOfLightning /= lightning.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
    }

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
            GameObject newLightning = Instantiate(lightning);
            newLightning.transform.position = new Vector3(nearestEnemy.transform.position.x, nearestEnemy.transform.position.y + halfSpriteOfLightning, nearestEnemy.transform.position.z);
        }
        Destroy(gameObject);
    }
}
