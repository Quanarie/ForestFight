using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private float minimalDistance;
    [SerializeField] private float maximalDistance;
    [SerializeField] private Tilemap[] tilemaps;
    [SerializeField] private Transform enemies;

    private void Start()
    {
        float randRadius = Random.Range(minimalDistance, maximalDistance);
        float randAng = Random.Range(0, Mathf.PI * 2);
        Vector3 portalPos = new Vector3(Mathf.Cos(randAng) * randRadius, Mathf.Sin(randAng) * randRadius, transform.position.z);
        portalPos.x += transform.position.x;
        portalPos.y += transform.position.y;
        GameObject newPortal = Instantiate(portalPrefab, portalPos, transform.rotation);
        newPortal.GetComponent<PortalTeleport>().SetTilemaps(tilemaps);
        newPortal.GetComponent<PortalTeleport>().SetPlayer(transform.gameObject);
        newPortal.GetComponent<PortalTeleport>().SetEnemies(enemies);
    }

    public void Spawn()
    {
        Start();
    }
}
