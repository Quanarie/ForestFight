using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : AbstractSkillUpgrade
{
    public override void Upgrade()
    {
        if (!isUpgraded)
        {
            if (previousSkill == null || previousSkill.isUpgraded)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                if (player.GetComponent<PlayerMoney>().CurrentMoney >= cost)
                {
                    player.GetComponent<PlayerMoney>().CurrentMoney -= cost;

                    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                    playerHealth.OnHealthUpgrade(playerHealth.GetMaxHealth() + toUpgrade);

                    isUpgraded = true;
                }
            }
            else
            {
                print("Upgrade prev skill first");
            }
        }
    }
}
