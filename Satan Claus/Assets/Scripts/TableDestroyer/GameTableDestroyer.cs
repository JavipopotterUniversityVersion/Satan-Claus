using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTableDestroyer : MonoBehaviour
{
    [SerializeField] GameObject rubbish;
    [SerializeField] GameObject brokenTable;
    private int hits = 0;
    
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
    public void OnHitEnter()
    {
        hits++;
        GenerateSomeRubbish();
        if (hits == 6)
        {
            DestroyTable();
        }
    }
    public void DestroyTable()
    {
        gameObject.SetActive(false);
        Instantiate(brokenTable, transform.position, Quaternion.identity);
    }
}
