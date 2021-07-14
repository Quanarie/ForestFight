using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject effect;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        Instantiate(effect, player.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
