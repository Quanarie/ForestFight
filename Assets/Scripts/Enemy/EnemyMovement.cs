using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void Update()
    {
        if (!player.gameObject.GetComponent<PlayerMovement>().isHidden ||
            Vector3.Distance(player.position, transform.position) < player.gameObject.GetComponent<PlayerMovement>().UnhiddenDistance)
        {
            Vector3 direction = new Vector3();
            direction.x = player.position.x - transform.position.x;
            direction.y = player.position.y - transform.position.y;

            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
        {
            player = target;
        }
    }
}
