using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float minTimeBtwDamage;
    [SerializeField] private float maxTimeBtwDamage;

    private Transform player;
    private Vector3 direction;
    private float currentTimeBetweenDamage;
    private float timeFromLastDamage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            GameObject closestEnemy = enemies[0];
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(player.position, closestEnemy.transform.position) > Vector3.Distance(player.position, enemy.transform.position))
                {
                    closestEnemy = enemy;
                }
            }

            direction = new Vector3(closestEnemy.transform.position.x - player.position.x, closestEnemy.transform.position.y - player.position.y, 0);
        }
        else
        {
            direction = Random.insideUnitCircle;
        }
        Destroy(gameObject, lifetime);

        currentTimeBetweenDamage = Random.Range(minTimeBtwDamage, maxTimeBtwDamage);
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeFromLastDamage >= currentTimeBetweenDamage)
        {
            if (collision.gameObject.TryGetComponent(out EnemyHealth _))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

                currentTimeBetweenDamage = Random.Range(minTimeBtwDamage, maxTimeBtwDamage);
                timeFromLastDamage = 0f;
            }
        }
        else
        {
            timeFromLastDamage += Time.deltaTime;
        }
    }
}
