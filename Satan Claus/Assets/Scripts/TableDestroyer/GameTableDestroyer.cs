using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTableDestroyer : MonoBehaviour
{
    [SerializeField] GameObject rubbish;
    public void GenerateRubbish()
    {
        Instantiate(rubbish, transform.position, Quaternion.identity);
    }
}
