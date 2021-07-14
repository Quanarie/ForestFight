using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleBerryPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject berry;
    [SerializeField] private float quantity;
    [SerializeField] private float radius;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        for (int i = 0; i < quantity; i++)
        {
            float randAng = Random.Range(0, 2 * Mathf.PI);
            Vector3 berryCoord = new Vector3(Mathf.Cos(randAng) * radius, Mathf.Sin(randAng) * radius, 0f);
            berryCoord.x += player.position.x;
            berryCoord.y += player.position.y;
            Instantiate(berry, berryCoord, transform.rotation);
        }

        Destroy(gameObject);
    }
}
