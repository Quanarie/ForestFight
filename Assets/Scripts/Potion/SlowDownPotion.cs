using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject effect;
    [SerializeField] private float lifeTime;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        GameObject slowDownEffect = Instantiate(effect, player.transform.position, transform.rotation);
        Destroy(slowDownEffect, lifeTime);

    }
}
