using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnMultiplier;
    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private Transform target;

    private float currentTimeBetweenSpawn;
    private float timeFromPreviousSpawn = 0f;

    private void Start()
    {
        currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (timeFromPreviousSpawn >= currentTimeBetweenSpawn)
        {
            /*float randRadius = Random.Range(0, Vector3.Distance(target.position, transform.position) * spawnMultiplier);
            float randAng = Random.Range(0, Mathf.PI * 2);
            Vector3 enemyPos = new Vector3(Mathf.Cos(randAng) * randRadius, Mathf.Sin(randAng) * randRadius, transform.position.z);
            enemyPos.x += transform.position.x;
            enemyPos.y += transform.position.y;*/

            Vector3 enemyPos = new Vector3();
            enemyPos.x = Random.Range(transform.position.x, target.position.x);
            enemyPos.y = Random.Range(transform.position.y, target.position.y);

            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], enemyPos, transform.rotation, enemiesParent);

            /*if (newEnemy.GetComponent<Renderer>().isVisible)*/

            newEnemy.GetComponent<EnemyMovement>().SetTarget(target);
            newEnemy.GetComponent<EnemyHealth>().SetPlayer(target.gameObject);

            timeFromPreviousSpawn = 0;
            currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
    public void SetEnemies(Transform enemiesParent) => this.enemiesParent = enemiesParent;
}
