using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroyed : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDestroy()
    {
        player.GetComponent<PortalSpawner>().Spawn(transform.position);
    }
}
