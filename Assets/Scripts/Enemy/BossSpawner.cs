using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bosses;

    private int currentBoss = 0;

    public void Spawn()
    {
        GameObject newBoss = Instantiate(bosses[currentBoss], Vector3.up, transform.rotation);
        newBoss.GetComponent<EnemyMovement>().SetTarget(transform);
        newBoss.GetComponent<EnemyHealth>().SetPlayer(transform.gameObject);
        currentBoss++;
    }
}
