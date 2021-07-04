using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minTimeBetweenDirectionChange;
    [SerializeField] private float maxTimeBetweenDirectionChange;

    private Transform player;
    private Animator animator;
    private Vector3 previousPosition;
    private Vector3 randomDirection;
    private float timeFromPreviousDirectionChange = 0f;
    private float timeBetweenDirectionChange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        randomDirection = Random.insideUnitCircle;
        timeBetweenDirectionChange = Random.Range(minTimeBetweenDirectionChange, maxTimeBetweenDirectionChange);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) >= player.gameObject.GetComponent<PlayerMovement>().UnhiddenDistance)
        {
            transform.Translate(randomDirection.normalized * speed * Time.deltaTime);

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
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }

            previousPosition = transform.position;
        }

        if (timeFromPreviousDirectionChange >= timeBetweenDirectionChange)
        {
            randomDirection = Random.insideUnitCircle;
            timeFromPreviousDirectionChange = 0f;
            timeBetweenDirectionChange = Random.Range(minTimeBetweenDirectionChange, maxTimeBetweenDirectionChange);
        }
        else
        {
            timeFromPreviousDirectionChange += Time.deltaTime;
        }
    }
}
