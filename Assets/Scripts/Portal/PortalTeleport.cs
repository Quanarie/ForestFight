using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class PortalTeleport : MonoBehaviour
{
    private GameObject player;
    private Tilemap[] tilemaps;
    private Transform enemies;
    private Transform potions;
    private TextMeshProUGUI newLevelText;

    private const float portalAnimationTime = 1f;

    public static int IngameLvl = 1;

    private void Start()
    {
        GetComponent<DifficultyController>().GameLvlChanged(IngameLvl);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement _))
        {
            collision.GetComponent<Animator>().SetTrigger("portal");

            IngameLvl++;
            newLevelText.text = "Level: " + IngameLvl.ToString();
            
            StartCoroutine(WaitForAnimationToEndAndTeleport());
        }
    }

    private IEnumerator WaitForAnimationToEndAndTeleport()
    {
        yield return new WaitForSeconds(portalAnimationTime);

        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.ClearAllTiles();
        }
        for (int child = 0; child < enemies.childCount; child++)
        {
            Destroy(enemies.GetChild(child).gameObject);
        }
        for (int child = 0; child < potions.childCount; child++)
        {
            Destroy(potions.GetChild(child).gameObject);
        }

        player.transform.position = new Vector3();
        player.GetComponent<TerrainGenerator>().Restart();
        player.GetComponent<ObstacleGenerator>().Restart();
        player.GetComponent<PotionGenerator>().Restart();
        player.GetComponent<PortalSpawner>().Spawn();
        newLevelText.text = "";
        Destroy(gameObject);
    }

    public void SetTilemaps(Tilemap[] TM) => tilemaps = TM;
    public void SetPlayer(GameObject P) => player = P;
    public void SetEnemies(Transform E) => enemies = E;
    public void SetPotions(Transform P) => potions = P;
    public void SetNewLevelText(TextMeshProUGUI T) => newLevelText = T;
}
