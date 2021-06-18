using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile earthTile;
    [SerializeField] private int generationRadius;

    private void LateUpdate()
    {
        for (int x = -generationRadius; x < generationRadius; x++)
        {
            for (int y = -generationRadius; y < generationRadius; y++)
            {
                Vector3Int newTile = tilemap.WorldToCell(transform.position);
                newTile.x += x;
                newTile.y += y;

                if (!tilemap.HasTile(newTile))
                {
                    tilemap.SetTile(newTile, earthTile);
                }
            }
        }
    }
}
