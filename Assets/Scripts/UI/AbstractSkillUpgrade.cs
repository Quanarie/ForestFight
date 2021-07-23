using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSkillUpgrade : MonoBehaviour
{
    [SerializeField] protected float toUpgrade;
    [SerializeField] protected float cost;
    [SerializeField] protected AbstractSkillUpgrade previousSkill;

    public bool isUpgraded { get; set; }

    public abstract void Upgrade();
}
