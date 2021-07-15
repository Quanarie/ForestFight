using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerForRooms : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] potions;
    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;
    [SerializeField] private Transform enemiesParent;

    private Inventory inventory;
    private Transform target;
    private float currentTimeBetweenSpawn;
    private float timeFromPreviousSpawn = 0f;
    private int maxNumberOfEnemies;
    private int currentNumberOfEnemies;
    private int maxLvlOfEnemy;
    private bool canSpawn;
    private const int potionNumber = 3;

    private GameObject lastEnemy;

    private GameObject portal;

    private void Start()
    {
        currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        canSpawn = false;

        portal = GameObject.FindGameObjectWithTag("Portal");
    }

    private void Update()
    {
        if (canSpawn)
        {
            portal.GetComponent<EnemySpawner>().enabled = false;

            if (timeFromPreviousSpawn >= currentTimeBetweenSpawn && currentNumberOfEnemies <= maxNumberOfEnemies)
            {
                Vector3 enemyPos = new Vector3();
                enemyPos.x = Random.Range(transform.position.x, target.position.x);
                enemyPos.y = Random.Range(transform.position.y, target.position.y);

                GameObject newEnemy = Instantiate(enemies[Random.Range(0, maxLvlOfEnemy)], enemyPos, transform.rotation, enemiesParent);

                /*if (newEnemy.GetComponent<Renderer>().isVisible)*/

                newEnemy.GetComponent<EnemyMovement>().SetTarget(target);
                newEnemy.GetComponent<EnemyHealth>().SetPlayer(target.gameObject);

                timeFromPreviousSpawn = 0;
                currentTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);

                lastEnemy = newEnemy;

                currentNumberOfEnemies++;
            }
            else if (currentNumberOfEnemies <= maxNumberOfEnemies)
            {
                timeFromPreviousSpawn += Time.deltaTime;
            }
            else if (lastEnemy == null)
            {
                SpawnPotions();
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _))
        {
            canSpawn = true;
        }
    }

    private void SpawnPotions()
    {
        for (int i = 0; i < potionNumber; i++)
        {
            Vector3 potionPos = transform.position;
            Vector2 randVect = Random.insideUnitCircle;
            potionPos.x += randVect.x;
            potionPos.y += randVect.y;
            GameObject newPotion = Instantiate(potions[Random.Range(0, Mathf.Min(PlayerExperience.Lvl * 2, potions.Length))], potionPos, transform.rotation);   // *2 !!!
            newPotion.GetComponent<Pickupable>().SetInventory(inventory);
        }

        portal.GetComponent<EnemySpawner>().enabled = true;
    }

    public void SetInventory(Inventory I) => inventory = I;
    public void SetPotions(GameObject[] P) => potions = P;
    public void SetMaxNumberOfEnemies(int N) => maxNumberOfEnemies = N;
    public void SetEnemies(Transform enemiesParent) => this.enemiesParent = enemiesParent;
    public void SetLvlOfEnemies(int L) => maxLvlOfEnemy = L;
    public void SetMinTimeBetweenSpawn(float M) => minTimeBetweenSpawn = M;
    public void SetMaxTimeBetweenSpawn(float M) => maxTimeBetweenSpawn = M;
    public float GetMinTimeBetweenSpawn() => minTimeBetweenSpawn;
    public float GetMaxTimeBetweenSpawn() => maxTimeBetweenSpawn;
}
