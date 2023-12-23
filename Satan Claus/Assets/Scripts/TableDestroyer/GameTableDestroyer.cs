using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTableDestroyer : MonoBehaviour
{
    [SerializeField] GameObject rubbish;
    [SerializeField] GameObject brokenTable;
    [SerializeField] RubbishInfo rubbishInfo;
    private int hits = 0;
    
    public void GenerateSomeRubbish()
    {
        int random = Random.Range(2, 4);

        for (int i = 0; i < random; i++)
        {
            rubbishInfo.rubbishCount++;
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
        AudioManager.instance.Play("bat_hit");
        GenerateSomeRubbish();
        if (hits == 6)
        {
            DestroyTable();
        }
    }
    public void DestroyTable()
    {
        Instantiate(brokenTable, transform.position, Quaternion.identity);
        gameObject.transform.position = new Vector3(1000, 1000, 0);
    }
}
