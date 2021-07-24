using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRecoveryUpgrade : AbstractSkillUpgrade
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

                    PlayerShield playerShield = player.GetComponent<PlayerShield>();
                    playerShield.OnArmorRecoveryChange(playerShield.RecoverySpeed + toUpgrade);

                    UnlockNextSkill();
                    ActivateCurrentSkill();
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
