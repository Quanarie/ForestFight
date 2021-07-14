using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VampirismPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private float percentOfHeal;
    [SerializeField] private float lifetime;

    private PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    public void Use()
    {
        playerAttack.percentOfVampireHeal = percentOfHeal;
        playerAttack.isVampiring = true;

        transform.SetParent(null);
        GetComponent<Image>().sprite = null;

        StartCoroutine(turnOffVampiring());
    }

    private IEnumerator turnOffVampiring()
    {
        yield return new WaitForSeconds(lifetime);

        playerAttack.isVampiring = false;
        Destroy(gameObject);
    }
}
