using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfirPlanePotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private GameObject efirBackground;
    [SerializeField] private float lifetime;

    private GameObject player;
    private Transform canvas;

    public void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        
        player.GetComponent<PlayerMovement>().UnhiddenDistance *= -1;
        Destroy(Instantiate(efirBackground, canvas), lifetime);

        transform.SetParent(null);
        GetComponent<Image>().sprite = null;

        StartCoroutine(ReturnUnhiddenDistance());
    }

    private IEnumerator ReturnUnhiddenDistance()
    {
        yield return new WaitForSeconds(lifetime);

        efirBackground.SetActive(false);
        player.GetComponent<PlayerMovement>().UnhiddenDistance *= -1;

        Destroy(gameObject);
    }
}
