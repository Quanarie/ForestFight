using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private int index;

    public void Use()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<AbstractPotion>().Use();
            GetComponentInParent<Inventory>().IsFull[index] = false;
        }
    }
}
