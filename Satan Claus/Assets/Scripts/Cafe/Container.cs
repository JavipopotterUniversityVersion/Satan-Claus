using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    Vector2 originalPosition;
    public int[] numberOfDrops = new int[4];

    private void Awake() {
        originalPosition = transform.position;
    }

    private void OnEnable() {
        transform.position = originalPosition;
    }

    public void ResetContainer()
    {
        for (int i = 0; i < numberOfDrops.Length; i++)
        {
            numberOfDrops[i] = 0;
        }
    }
}