using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxHealth;
    [SerializeField] private float experienceForKilling;

    private Animator animator;

    private float currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        DamageDisplay.Instance.AddText((int)damage, transform.position);

        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;

            animator.SetTrigger("damage");
        }
        else
        {
            player.GetComponent<PlayerExperience>().CurrentExperience = player.GetComponent<PlayerExperience>().CurrentExperience + experienceForKilling;
            player.GetComponent<PlayerMoney>().CurrentMoney = player.GetComponent<PlayerMoney>().CurrentMoney + 1;

            Destroy(gameObject);
        }
    }

    public void SetPlayer(GameObject player)
    {
        if (player != null)
        {
            this.player = player;
        }
    }
}
