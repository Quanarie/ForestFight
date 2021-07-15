using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private Slider experienceSlider;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI lvlText;

    public static int Lvl = 1;

    private const int numberOfLvls = 20;
    private const float lvlUpMultiplicator = 2f;

    public float CurrentExperience
    {
        get
        {
            return experienceSlider.value;
        }
        set
        {
            if (value < experienceSlider.maxValue)
            {
                experienceSlider.value = value;
            }
            else if (Lvl < numberOfLvls)
            {
                experienceSlider.value = value - experienceSlider.maxValue;
                experienceSlider.maxValue *= lvlUpMultiplicator;
                Lvl++;
                lvlText.text = Lvl.ToString();
            }
            else
            {
                experienceSlider.value = experienceSlider.maxValue;
            }

            expText.text = experienceSlider.value.ToString() + " / " + experienceSlider.maxValue.ToString();
        }
    }

    public float AllExperience
    {
        get
        {
            int lvl = Lvl - 1;
            float exp = 0;
            while (lvl > 0)
            {
                exp += Mathf.Pow(2, lvl);
                lvl--;
            }
            exp += CurrentExperience;
            return exp;
        }
    }
}
