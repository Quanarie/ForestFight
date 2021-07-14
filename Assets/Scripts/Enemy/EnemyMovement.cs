using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private CircleCollider2D attackCollider;
    [SerializeField] private float RENDanger;

    private Vector3 previousPosition;
    private Animator animator;

    private bool isToPlayer = true;
    private bool isScared = false;

    private void Start()
    {
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < player.gameObject.GetComponent<PlayerMovement>().UnhiddenDistance &&
            distance >= attackCollider.radius)
        {

            if (distance < player.gameObject.GetComponent<REN>().GetDangerRadius())
            {
                if (RENDanger < player.gameObject.GetComponent<REN>().GetDanger()) isScared = true;
            }

            Vector3 direction = new Vector3();
            if (isToPlayer && !isScared)
            {
                direction.x = player.position.x - transform.position.x;
                direction.y = player.position.y - transform.position.y;
            }
            else
            {
                direction.x = - player.position.x + transform.position.x;
                direction.y = - player.position.y + transform.position.y;
            }

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            if (transform.position.x < previousPosition.x && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x > previousPosition.x && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            if (transform.position == previousPosition)
            {
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isRunning", true);
            }

            previousPosition = transform.position;
        }
    }

    public void SetDirection(bool isToPlayer) => this.isToPlayer = isToPlayer;

    public void SetTarget(Transform target)
    {
        if (target != null)
        {
            player = target;
        }
    }
}
