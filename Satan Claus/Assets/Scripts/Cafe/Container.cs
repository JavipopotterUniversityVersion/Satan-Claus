using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    Vector2 originalPosition;
    Quaternion originalRotation;
    public int[] numberOfDrops = new int[4];

    private void Awake() {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnEnable() {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        ResetContainer();
    }

    public void ResetContainer()
    {
        for (int i = 0; i < numberOfDrops.Length; i++)
        {
            numberOfDrops[i] = 0;
        }
    }
}