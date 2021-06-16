using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        Vector3 pos = Vector2.Lerp(transform.position, player.position, 0.05f);
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
