using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastmovePotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private float multiplyCoef = 1.5f;
    [SerializeField] private float timeForEffect = 10f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        player.GetComponent<PlayerMovement>().Speed *= multiplyCoef;

        transform.SetParent(null);
        GetComponent<Image>().sprite = null;

        StartCoroutine(ReturnSpeedToNormal());
    }

    private IEnumerator ReturnSpeedToNormal()
    {
        yield return new WaitForSeconds(timeForEffect);

        player.GetComponent<PlayerMovement>().Speed /= multiplyCoef;
        Destroy(gameObject);
    }
}
