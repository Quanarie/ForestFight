using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private int minNumberOfRooms;
    [SerializeField] private int maxNumberOfRooms;
    [SerializeField] private int minNumberOfMobs;
    [SerializeField] private int maxNumberOfMobs;
    [SerializeField] private float roomSpacing;
    [SerializeField] private Vector2 leftUpCoord;
    [SerializeField] private Vector2 rightDownCoord;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private float difficulty;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform roomsParent;
    [SerializeField] private int actionRadius;
    [SerializeField] private Tilemap treeTileMap;
    [SerializeField] private Vector2 offset;

    private EnemySpawner currentEnemySpawner;

    private int maxLvlOfEnemy;
    private float minTimeBetweenSpawn;
    private float maxTimeBetweenSpawn;
    private float currentNumberOfRooms;

    private Vector3 prevRoomPos = Vector3.zero;

    private void Start()
    {
        currentEnemySpawner = GameObject.FindGameObjectWithTag("Portal").GetComponent<EnemySpawner>();
        maxLvlOfEnemy = currentEnemySpawner.GetLvlOfEnemies();
        minTimeBetweenSpawn = currentEnemySpawner.GetMinTimeBetweenSpawn() / difficulty;
        maxTimeBetweenSpawn = currentEnemySpawner.GetMaxTimeBetweenSpawn() / difficulty;
        currentNumberOfRooms = Random.Range(maxNumberOfRooms, maxNumberOfRooms);

        for (int i = 0; i < currentNumberOfRooms; i++)
        {
            Vector3 roomPos = new Vector3();
            while (Vector3.Distance(prevRoomPos, roomPos) < roomSpacing)
            {
                roomPos.x = Random.Range(leftUpCoord.x, rightDownCoord.x);
                roomPos.y = Random.Range(rightDownCoord.y, leftUpCoord.y);
            }
            
            GameObject newRoom = Instantiate(room, roomPos, transform.rotation, roomsParent);
            EnemySpawnerForRooms enemySpawner = newRoom.GetComponent<EnemySpawnerForRooms>();

            enemySpawner.SetMinTimeBetweenSpawn(minTimeBetweenSpawn);
            enemySpawner.SetMaxTimeBetweenSpawn(maxTimeBetweenSpawn);
            enemySpawner.SetLvlOfEnemies(maxLvlOfEnemy);
            enemySpawner.SetEnemies(enemiesParent);
            enemySpawner.SetInventory(inventory);
            enemySpawner.SetMaxNumberOfEnemies(Random.Range(minNumberOfMobs, maxNumberOfMobs));

            for (int x = treeTileMap.WorldToCell(roomPos).x - actionRadius; x < treeTileMap.WorldToCell(roomPos).x + actionRadius; x++)
            {
                for (int y = treeTileMap.WorldToCell(roomPos).y - actionRadius; y < treeTileMap.WorldToCell(roomPos).y + actionRadius; y++)
                {
                    treeTileMap.SetTile(new Vector3Int(x + (int)offset.x, y + (int)offset.y, 0), null);
                }
            }
        }
    }

    public void Spawn()
    {
        Start();
    }
}
