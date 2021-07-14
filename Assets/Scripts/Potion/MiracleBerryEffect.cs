using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleBerryEffect : MonoBehaviour
{
    [SerializeField] private float toHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Heal(toHeal);

            Destroy(gameObject);
        }
    }
}
