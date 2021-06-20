using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float unhiddenDistance;
    [SerializeField] private float dodgeDistance;
    [SerializeField] private float dodgeRechargeTime;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Slider stealthUpgradeSlider;

    private Animator animator;
    private float timeFromPreviousDodge;

    private void Start()
    {
        stealthUpgradeSlider.value = -unhiddenDistance;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;

        Vector3 pos = transform.position;
        pos.x += xAxis * Time.deltaTime * speed;
        pos.y += yAxis * Time.deltaTime * speed;

        if (pos.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (pos.x > transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (xAxis == 0 && yAxis == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        transform.position = pos;

        timeFromPreviousDodge += Time.deltaTime;
    }

    public void Dodge()
    {
        if (timeFromPreviousDodge >= dodgeRechargeTime)
        {
            Vector3 pos = transform.position;
            pos.x -= dodgeDistance * Mathf.Abs(transform.localScale.x) / transform.localScale.x;
            transform.position = pos;

            animator.SetTrigger("dodge");

            timeFromPreviousDodge = 0;
        }
    }

    public void OnStealthValueChange(float newStealthValue)
    {
        if (newStealthValue > -unhiddenDistance)
        {
            unhiddenDistance = -newStealthValue;
        }
    }

    public float UnhiddenDistance
    {
        get
        {
            return unhiddenDistance;
        }
        set
        {
            if (value > 0)
            {
                unhiddenDistance = value;
            }
        }
    }
}