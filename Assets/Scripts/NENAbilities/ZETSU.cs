using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZETSU : MonoBehaviour, AbstractNENAbility
{
    public void Activate()
    {
        GetComponent<PlayerMovement>().isVisible = false;
    }

    public void Disactivate()
    {
        GetComponent<PlayerMovement>().isVisible = true;
    }
}
