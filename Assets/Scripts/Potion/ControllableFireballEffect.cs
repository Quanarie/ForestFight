using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllableFireballEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float minTimeBtwDamage;
    [SerializeField] private float maxTimeBtwDamage;

    private float currentTimeBetweenDamage;
    private float timeFromLastDamage;
    private GameObject joystickObject;
    private Joystick joystick;

    private void Start()
    {
        joystickObject = GameObject.FindGameObjectWithTag("FireballJoystick");
        joystickObject.GetComponent<Image>().enabled = true;
        joystickObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
        joystick = joystickObject.GetComponent<Joystick>();

        currentTimeBetweenDamage = Random.Range(minTimeBtwDamage, maxTimeBtwDamage);

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;

        Vector3 pos = transform.position;
        pos.x += xAxis * Time.deltaTime * speed;
        pos.y += yAxis * Time.deltaTime * speed;

        transform.position = pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeFromLastDamage >= currentTimeBetweenDamage)
        {
            if (collision.gameObject.TryGetComponent(out EnemyHealth _))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

                currentTimeBetweenDamage = Random.Range(minTimeBtwDamage, maxTimeBtwDamage);
                timeFromLastDamage = 0f;
            }
        }
        else
        {
            timeFromLastDamage += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        joystickObject.GetComponent<Image>().enabled = false;
        joystickObject.transform.GetChild(0).GetComponent<Image>().enabled = false;
    }
}
