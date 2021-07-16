using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tile[] obstacles;
    [SerializeField] private int squareSize;

    private const float chanceOfSpawn = 0.985f;

    private void Start()
    {
        for (int i = -squareSize; i < squareSize; i++)
        {
            for (int j = -squareSize; j < squareSize; j++)
            {
                Vector3Int newTilePos = new Vector3Int(i, j, 0);
                if (groundTilemap.HasTile(newTilePos) && Random.value > chanceOfSpawn)
                {
                    tilemap.SetTile(newTilePos, obstacles[Random.Range(0, obstacles.Length)]);
                }
            }
        }
    }

    public void Restart()
    {
        Start();
    }
}
