using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private float moneyValue = 0f;

    public float CurrentMoney 
    { 
        get
        {
            return moneyValue;
        }
        set
        {
            moneyValue = value;
            moneyText.text = moneyValue.ToString();
        }
    }
}
