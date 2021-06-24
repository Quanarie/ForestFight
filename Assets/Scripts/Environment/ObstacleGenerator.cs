using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] tiles;
    [SerializeField] private float spawnRechargeTime;

    private float visibleRadius;
    private float timeFromPreviousSpawn = 0f;

    private void Start()
    {
        visibleRadius = GetComponent<PlayerMovement>().UnhiddenDistance;
    }

    private void Update()
    {
        if (timeFromPreviousSpawn >= spawnRechargeTime)
        {
            Vector3Int obstaclePosition = tilemap.WorldToCell(transform.position);
            int randSign = Random.Range(-1, 2);
            obstaclePosition.x += (int)Random.Range(visibleRadius, visibleRadius * 2) * randSign;
            obstaclePosition.y += (int)Random.Range(visibleRadius, visibleRadius * 2) * randSign;

            if (!tilemap.HasTile(obstaclePosition))
            {
                tilemap.SetTile(obstaclePosition, tiles[(int)(Random.Range(0f, tiles.Length))]);
            }

            timeFromPreviousSpawn = 0f;
        }
        else
        {
            timeFromPreviousSpawn += Time.deltaTime;
        }
    }
}
