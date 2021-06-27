using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject objectImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < inventory.IsFull.Length; i++)
        {
            if (inventory.IsFull[i] == false)
            {
                bool[] tempArray = inventory.IsFull;
                tempArray[i] = true;
                inventory.IsFull = tempArray;
                Instantiate(objectImage, inventory.Slots[i].transform);
                Destroy(gameObject);
                break;
            }
        }
    }
}
