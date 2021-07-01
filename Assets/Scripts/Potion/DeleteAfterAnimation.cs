using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterAnimation : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;

    private void Start()
    {
        Destroy(gameObject, clip.length);
    }
}
