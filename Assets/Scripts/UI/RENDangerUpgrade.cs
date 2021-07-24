using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RENDangerUpgrade : AbstractSkillUpgrade
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

                    REN playerREN = player.GetComponent<REN>();
                    playerREN.OnRENDangerValueChanged(playerREN.GetDanger() + toUpgrade);

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
