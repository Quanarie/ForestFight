using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject flashBG;
    [SerializeField] private float damage;

    private Image flashBGImage;

    private void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        flashBGImage = Instantiate(flashBG, canvas.transform).GetComponent<Image>();

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Destroy(flashBGImage.gameObject, lifeTime);
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        flashBGImage.color = new Color(flashBGImage.color.r, flashBGImage.color.g,
            flashBGImage.color.b, flashBGImage.color.a + Time.deltaTime);
    }
}
