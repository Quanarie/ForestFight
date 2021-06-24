using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float visibleRadius;
    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;

    private float currentTimeBetweenSpawn;
    private float timeFromPreviousSpawn = 0f;

    private void Start()
    {
        currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
    }

    private void Update()
    {
        if (timeFromPreviousSpawn >= currentTimeBetweenSpawn)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
            Vector3 enemyPosition = transform.position;
            Vector3 enemyShift = Random.insideUnitCircle * spawnRadius;
            enemyPosition.x += enemyShift.x;
            enemyPosition.y += enemyShift.y;
            if (Vector3.Distance(enemyPosition, transform.position) < visibleRadius)
            {
                enemyPosition *= spawnRadius / visibleRadius;
            }
            enemy.transform.position = enemyPosition;

            enemy.GetComponent<EnemyMovement>().SetTarget(transform);

            timeFromPreviousSpawn = 0;
            currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
}
