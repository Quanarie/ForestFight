using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    private bool isFacingRight = true;

    private void Update()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;

        Vector3 pos = transform.position;
        pos.x += xAxis * Time.deltaTime * speed;
        pos.y += yAxis * Time.deltaTime * speed;

        if (pos.x < transform.position.x && isFacingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = false;
        }
        else if (pos.x > transform.position.x && !isFacingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }

        transform.position = pos;
    }
}
