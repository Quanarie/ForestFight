using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] obstacles;
    [SerializeField] private float spawnDistance;   //distance that player should pass to spawn another obstacle
    [SerializeField] private float spawnRadius;
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
            float randRadius = Random.Range(visibleRadius, spawnRadius);
            float randAng = Random.Range(0, Mathf.PI * 2);
            Vector3 obstacleOffset = new Vector3(Mathf.Cos(randAng) * randRadius, Mathf.Sin(randAng) * randRadius, transform.position.z);
            obstaclePos.x += (int)transform.position.x + (int)obstacleOffset.x;
            obstaclePos.y += (int)transform.position.y + (int)obstacleOffset.y;

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
