using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotionGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private GameObject[] potions;
    [SerializeField] private Transform potionParent;
    [SerializeField] private Inventory inventory;
    [SerializeField] private int squareSize;

    private const float chanceOfSpawn = 0.99f;

    private void Start()
    {
        for (int i = -squareSize; i < squareSize; i++)
        {
            for (int j = -squareSize; j < squareSize; j++)
            {
                Vector3Int newTilePos = new Vector3Int(i, j, 0);
                if (groundTilemap.HasTile(newTilePos) && Random.value > chanceOfSpawn)
                {
                    GameObject newPotion = Instantiate(potions[Random.Range(0, potions.Length)], groundTilemap.CellToWorld(newTilePos), transform.rotation, potionParent);
                    newPotion.GetComponent<Pickupable>().SetInventory(inventory);
                }
            }
        }
    }

    public void Restart()
    {
        Start();
    }
}
