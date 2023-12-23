using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CupInfo", menuName = "ScriptableObjects/CupInfo", order = 1)]
public class CupInfo : ScriptableObject
{
    public int[] numberOfDrops = new int[4];

    public void Restart()
    {
        for (int i = 0; i < numberOfDrops.Length; i++)
        {
            numberOfDrops[i] = 0;
        }
    }
}
