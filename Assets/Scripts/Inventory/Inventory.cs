using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;

    public bool[] IsFull { get; set; }

    public GameObject[] Slots
    {
        get { return slots; }
    }

    public bool isInventoryOn { get; set; }

    private void Start()
    {
        IsFull = new bool[slots.Length];
    }

    public void InventoryOn()
    {
        if (isInventoryOn)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            isInventoryOn = false;
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            isInventoryOn = true;
        }
    }
}
