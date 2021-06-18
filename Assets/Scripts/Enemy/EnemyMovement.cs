using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= Mathf.Sign(pos.x - player.position.x) * speed * Time.deltaTime;
        pos.y -= Mathf.Sign(pos.y - player.position.y) * speed * Time.deltaTime;

        transform.position = pos;
    }
}
