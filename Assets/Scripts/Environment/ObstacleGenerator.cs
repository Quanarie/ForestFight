using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] obstacles;
    [SerializeField] private float spawnDistance;   //distance that player should pass to spawn another obstacle
    [SerializeField] private float visibleRadius;

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
            Vector3Int obstaclePos = tilemap.WorldToCell(transform.position);
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

            tilemap.SetTile(obstaclePos, obstacles[Random.Range(0, obstacles.Length)]);

            distanceFromPreviousSpawn = 0f;
        }
        else
        {
            distanceFromPreviousSpawn += Vector3.Distance(previousPosition, transform.position);
        }

        previousPosition = transform.position;
    }
}
