using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider healthUpgradeSlider;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthUpgradeSlider.value = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        DamageDisplay.Instance.AddText((int)damage, transform.position);

        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;

            healthSlider.value = currentHealth;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnHealthUpgrade(float newHealth)
    {
        if (newHealth > maxHealth)
        {
            maxHealth = newHealth;
        }

        healthSlider.maxValue = maxHealth;
    }

    public void Heal(float toHeal)
    {
        if (toHeal > 0)
        {
            if (currentHealth + toHeal > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += toHeal;
            }

            healthSlider.value = currentHealth;
        }
    }

    public float GetMaxHealth() => maxHealth;
}
