using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private RuntimeAnimatorController[] enemiesControllers;
    [SerializeField] private float actionTime;
    [SerializeField] private RuntimeAnimatorController playerAnimatorNEN;
    [SerializeField] private RuntimeAnimatorController playerAnimatorREN;
    [SerializeField] private RuntimeAnimatorController playerAnimatorZETSU;

    private GameObject player;
    private int availableLength;

    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerShield playerShield;
    private PlayerHealth playerHealth;
    private Animator playerAnimator;

    private float playerSpeed;
    private float playerAttackDamage;
    private float playerRecharge;
    private float playerMaxHealth;
    private float playerCurrentHealth;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerHealth>().OnDeathWhenIsMonster += returnAnimator;
        player.GetComponent<PlayerHealth>().OnDeathWhenIsMonster += returnProperties;

        availableLength = Mathf.Min(PortalTeleport.IngameLvl, enemies.Length);

        playerMovement = player.GetComponent<PlayerMovement>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerShield = player.GetComponent<PlayerShield>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAnimator = player.GetComponent<Animator>();
    }

    private void RememberInfo()
    {
        playerSpeed = playerMovement.Speed;
        playerAttackDamage = playerAttack.Damage;
        playerRecharge = playerAttack.RechargeTime;
        playerMaxHealth = playerHealth.MaxHealth;
        playerCurrentHealth = playerHealth.CurrentHealth;
    }

    public void Use()
    {
        RememberInfo();

        int randomMonster = Random.Range(0, availableLength);

        playerAnimator.runtimeAnimatorController = enemiesControllers[randomMonster];
        playerMovement.Speed = enemies[randomMonster].GetComponent<EnemyMovement>().Speed;
        playerAttack.Damage = enemies[randomMonster].GetComponent<EnemyAttack>().GetDamage();
        playerAttack.RechargeTime = enemies[randomMonster].GetComponent<EnemyAttack>().GetRechargeTime();
        playerShield.isMonster = true;
        playerShield.GetArmorSlider().gameObject.SetActive(false);
        playerHealth.MaxHealth = enemies[randomMonster].GetComponent<EnemyHealth>().MaxHealth;
        playerHealth.CurrentHealth = enemies[randomMonster].GetComponent<EnemyHealth>().MaxHealth;
        playerHealth.GetHealthSlider().maxValue = enemies[randomMonster].GetComponent<EnemyHealth>().MaxHealth;
        playerHealth.isMonster = true;

        transform.SetParent(null);

        //StartCoroutine(waitAndReturnPropetries());
    }

    private IEnumerator waitAndReturnPropetries()
    {
        yield return new WaitForSeconds(actionTime);

        returnAnimator();
        returnProperties();
    }

    private void returnAnimator()
    {
        int currentAbility = player.GetComponent<NENChanger>().GetCurrentAbility();
        if (currentAbility == 0) playerAnimator.runtimeAnimatorController = playerAnimatorNEN;
        else if (currentAbility == 1) playerAnimator.runtimeAnimatorController = playerAnimatorREN;
        else if (currentAbility == 2) playerAnimator.runtimeAnimatorController = playerAnimatorZETSU;
    }

    private void returnProperties()
    {
        playerMovement.Speed = playerSpeed;
        playerAttack.Damage = playerAttackDamage;
        playerAttack.RechargeTime = playerRecharge;
        playerShield.isMonster = false;
        playerShield.GetArmorSlider().gameObject.SetActive(true);
        playerHealth.GetHealthSlider().maxValue = playerMaxHealth;
        playerHealth.GetHealthSlider().value = playerCurrentHealth;
        print(playerCurrentHealth);
        playerHealth.MaxHealth = playerMaxHealth;
        playerHealth.CurrentHealth = playerCurrentHealth;
        playerHealth.isMonster = false;
    }
}
