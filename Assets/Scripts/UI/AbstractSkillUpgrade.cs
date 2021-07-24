using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSkillUpgrade : MonoBehaviour
{
    [SerializeField] protected float toUpgrade;
    [SerializeField] protected float cost;
    [SerializeField] protected AbstractSkillUpgrade previousSkill;
    [SerializeField] protected AbstractSkillUpgrade[] nextSkills;

    public bool isUpgraded { get; set; }

    public abstract void Upgrade();

    protected void UnlockNextSkill()
    {
        foreach (AbstractSkillUpgrade skill in nextSkills)
        {
            if (skill != null)
            {
                Color color = skill.GetComponent<Image>().color;
                color.a = 0.75f;

                skill.GetComponent<Image>().color = color;
            }
        }
    }

    protected void ActivateCurrentSkill()
    {
        Color color = GetComponent<Image>().color;
        color.a = 1f;

        GetComponent<Image>().color = color;
    }
}
