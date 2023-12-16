using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTableDestroyer : MonoBehaviour
{
    [SerializeField] GameObject rubbish;
    
    public void GenerateSomeRubbish()
    {
        int random = Random.Range(2, 4);

        for (int i = 0; i < random; i++)
        {
            GenerateRubbish();
        }
    }
    public void GenerateRubbish()
    {
        Instantiate(rubbish, transform.position, Quaternion.identity);
    }
}
