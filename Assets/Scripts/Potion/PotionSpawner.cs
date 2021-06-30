using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] potions;
    [SerializeField] private float spawnDistance;   //distance that player should pass to spawn another obstacle
    [SerializeField] private float visibleRadius;
    [SerializeField] private Inventory inventory;

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
            Vector3 obstaclePos = transform.position;
            if (Random.value >= 0.5f)
            {
                obstaclePos.x += (int)Random.Range(visibleRadius, 2 * visibleRadius);
            }
            else
            {
                obstaclePos.x -= (int)Random.Range(visibleRadius, 2 * visibleRadius);
            }
            if (Random.value >= 0.5f)
            {
                obstaclePos.y += (int)Random.Range(visibleRadius, 2 * visibleRadius);
            }
            else
            {
                obstaclePos.y -= (int)Random.Range(visibleRadius, 2 * visibleRadius);
            }

            GameObject newPotion = Instantiate(potions[Random.Range(0, potions.Length)], obstaclePos, transform.rotation);
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