using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZETSU : MonoBehaviour, AbstractNENAbility
{
    private const float hiddenCoefficient = 1.5f;
    private const float cameraCoefficient = 1.5f;

    public void Activate()
    {
        GetComponent<PlayerMovement>().UnhiddenDistance = GetComponent<PlayerMovement>().UnhiddenDistance / hiddenCoefficient;
        Camera.main.orthographicSize *= cameraCoefficient;
    }

    public void Disactivate()
    {
        GetComponent<PlayerMovement>().UnhiddenDistance = GetComponent<PlayerMovement>().UnhiddenDistance * hiddenCoefficient;
        Camera.main.orthographicSize /= cameraCoefficient;
    }
}
