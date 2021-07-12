using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile[] tiles;
    [SerializeField] private int squareSize;

    private void Awake()
    {
        for (int i = -squareSize; i < squareSize; i++)
        {
            for (int j = -squareSize; j < squareSize; j++)
            {
                Vector3Int newTilePos = new Vector3Int(i, j, 0);
                if (tilemap.HasTile(newTilePos))
                {
                    tilemap.SetTile(newTilePos, tiles[(int)(Random.Range(0f, tiles.Length) * Random.Range(0f, 0.8f))]);
                }
            }
        }
    }

    public void Restart()
    {
        Awake();
    }

    /*private void LateUpdate()
    {
        for (int x = -generationRadius; x < generationRadius; x++)
        {
            for (int y = -generationRadius; y < generationRadius; y++)
            {
                Vector3Int newTilePos = tilemap.WorldToCell(transform.position);
                newTilePos.x += x;
                newTilePos.y += y;

                if (!tilemap.HasTile(newTilePos))
                {
                    tilemap.SetTile(newTilePos, tiles[(int)(Random.Range(0f, tiles.Length) * Random.Range(0f, 0.8f))]);
                }
            }
        }
    }*/
}
