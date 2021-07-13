using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private float minimalDistance;
    [SerializeField] private float maximalDistance;
    [SerializeField] private Tilemap[] tilemaps;
    [SerializeField] private Transform enemies;
    [SerializeField] private Transform potions;
    [SerializeField] private TextMeshProUGUI newLevelText;

    private PortalTeleport portalTeleport;

    private void Start()
    {
        float randRadius = Random.Range(minimalDistance, maximalDistance);
        float randAng = Random.Range(0, Mathf.PI * 2);
        Vector3 portalPos = new Vector3(Mathf.Cos(randAng) * randRadius, Mathf.Sin(randAng) * randRadius, transform.position.z);
        portalPos.x += transform.position.x;
        portalPos.y += transform.position.y;

        GameObject newPortal = Instantiate(portalPrefab, portalPos, transform.rotation);
        portalTeleport = newPortal.GetComponent<PortalTeleport>();

        portalTeleport.SetTilemaps(tilemaps);
        portalTeleport.SetPlayer(transform.gameObject);
        portalTeleport.SetEnemies(enemies);
        portalTeleport.SetPotions(potions);
        portalTeleport.SetNewLevelText(newLevelText);
        newPortal.GetComponent<EnemySpawner>().SetEnemies(enemies);
    }

    public void Spawn()
    {
        Start();
    }

    public void Spawn(Vector3 pos)
    {
        GameObject newPortal = Instantiate(portalPrefab, pos, transform.rotation);
        portalTeleport = newPortal.GetComponent<PortalTeleport>();

        portalTeleport.SetTilemaps(tilemaps);
        portalTeleport.SetPlayer(transform.gameObject);
        portalTeleport.SetEnemies(enemies);
        portalTeleport.SetPotions(potions);
        portalTeleport.SetNewLevelText(newLevelText);
        newPortal.GetComponent<EnemySpawner>().enabled = false;
    }
}
