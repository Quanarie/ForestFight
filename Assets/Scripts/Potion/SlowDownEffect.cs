using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float radius;
    [SerializeField] private float speedSlowerMultiplier;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMovement _))
        {
            collision.gameObject.GetComponent<EnemyMovement>().Speed /= speedSlowerMultiplier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMovement _))
        {
            collision.gameObject.GetComponent<EnemyMovement>().Speed *= speedSlowerMultiplier;
        }
    }
}
