using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float upgradeCost;

    public void Upgrade(float toUpgrade)
    {
        if (player.GetComponent<PlayerMoney>().CurrentMoney >= upgradeCost)
        {
            player.GetComponent<PlayerMoney>().CurrentMoney -= upgradeCost;
            GetComponent<Slider>().value += toUpgrade;
        }
    }
}
