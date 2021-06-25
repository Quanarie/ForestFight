using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortalTeleport : MonoBehaviour
{
    private GameObject player;
    private Tilemap[] tilemaps;
    private Transform enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement _))
        {
            player.GetComponent<PortalSpawner>().Spawn();
            Destroy(gameObject);
            foreach (Tilemap tilemap in tilemaps)
            {
                tilemap.ClearAllTiles();
            }
            for (int child = 0; child < enemies.childCount; child++)
            {
                Destroy(enemies.GetChild(child).gameObject);
            }
        }
    }

    public void SetTilemaps(Tilemap[] TM) => tilemaps = TM;
    public void SetPlayer(GameObject P) => player = P;
    public void SetEnemies(Transform E) => enemies = E;
}
