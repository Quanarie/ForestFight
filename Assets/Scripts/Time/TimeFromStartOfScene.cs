using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFromStartOfScene : MonoBehaviour
{
    private static float timeFromStartOfScene = 0f;

    private void Update()
    {
        timeFromStartOfScene += Time.deltaTime;
    }

    public static float GetTimeFromStartOfScene() => timeFromStartOfScene;
}
