using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] potions;
    [SerializeField] private float spawnDistance;   //distance that player should pass to spawn another obstacle
    [SerializeField] private float spawnRadius;
    [SerializeField] private float visibleRadius;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform potionParent;

    private float distanceFromPreviousSpawn = 0f;
    private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (distanceFromPreviousSpawn >= spawnDistance)
        {
            float randRadius = Random.Range(visibleRadius, spawnRadius);
            float randAng = Random.Range(0, Mathf.PI * 2);
            Vector3 obstaclePos = new Vector3(Mathf.Cos(randAng) * randRadius, Mathf.Sin(randAng) * randRadius, transform.position.z);
            obstaclePos.x += transform.position.x;
            obstaclePos.y += transform.position.y;
            GameObject newPotion = Instantiate(potions[Random.Range(0, potions.Length)], obstaclePos, transform.rotation, potionParent);

            newPotion.GetComponent<Pickupable>().SetInventory(inventory);

            distanceFromPreviousSpawn = 0f;
        }
        else
        {
            distanceFromPreviousSpawn += Vector3.Distance(previousPosition, transform.position);
        }

        previousPosition = transform.position;
    }
}