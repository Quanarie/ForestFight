using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 direction = new Vector3();
        direction.x = player.position.x - transform.position.x;
        direction.y = player.position.y - transform.position.y;

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
        {
            player = target;
        }
    }
}
