using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private float toHeal;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        player.GetComponent<PlayerHealth>().Heal(toHeal);
        Destroy(gameObject);
    }
}
