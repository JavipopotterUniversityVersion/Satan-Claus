using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGenerator : MonoBehaviour
{
    [SerializeField] entity drop;
    [SerializeField] Transform dropPosition;

    public void GenerateDrop()
    {
        GameObject obj = ObjectPooler.pooler.GetObject(drop, dropPosition.position).gameObject;
    }
}
