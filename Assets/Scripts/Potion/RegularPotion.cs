using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject effect;
    [SerializeField] private Vector3 spawnOffset;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void Use()
    {
        Instantiate(effect, new Vector3(player.transform.position.x + spawnOffset.x, player.transform.position.y + spawnOffset.y, 0), transform.rotation);
        Destroy(gameObject);
    }
}
