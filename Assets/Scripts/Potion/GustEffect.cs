using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;

    private Transform player;
    private Vector3 direction;
    private List<EnemyMovement> enemyMovements;

    private void Start()
    {
        enemyMovements = new List<EnemyMovement>();

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
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMovement _))
        {
            EnemyMovement enemyMovement = collision.gameObject.GetComponent<EnemyMovement>();
            enemyMovement.enabled = false;
            enemyMovements.Add(enemyMovement);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMovement _))
        {
            collision.gameObject.transform.position = Vector3.Lerp(transform.position, player.position, 0.1f);
        }
    }

    private void OnDestroy()
    {
        foreach(EnemyMovement enemyMovement in enemyMovements)
        {
            enemyMovement.enabled = true;
        }
    }
}
