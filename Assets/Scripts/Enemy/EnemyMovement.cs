using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private CircleCollider2D attackCollider;

    private Vector3 previousPosition;
    private Animator animator;

    private bool isToPlayer = true;

    private void Start()
    {
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < player.gameObject.GetComponent<PlayerMovement>().UnhiddenDistance &&
            Vector3.Distance(player.position, transform.position) >= attackCollider.radius)
        {
            Vector3 direction = new Vector3();
            if (isToPlayer)
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
