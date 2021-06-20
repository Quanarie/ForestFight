using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUpgrade : MonoBehaviour
{
    public void Upgrade(float toUpgrade)
    {
        GetComponent<Slider>().value += toUpgrade;
    }
}
