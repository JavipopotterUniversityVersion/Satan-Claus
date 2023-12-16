using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int[] numberOfDrops = new int[4];

    void ResetContainer()
    {
        for (int i = 0; i < numberOfDrops.Length; i++)
        {
            numberOfDrops[i] = 0;
        }
    }
}