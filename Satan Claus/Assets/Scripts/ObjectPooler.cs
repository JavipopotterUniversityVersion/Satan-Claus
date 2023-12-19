using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum entity
{
    lava, salt, virginBlood
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler pooler;
    [SerializeField] GameObject[] OBJECTS_TO_INSTANTIATE;
    [SerializeField] Transform gameElementsContainer;
    List<List<GameObject>> objects;
    private void Awake() {
        objects = new List<List<GameObject>>()
        {
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>()
        };

        if(pooler == null)
        {
            pooler = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CreateObjects();
    }

    void CreateObjects()
    {
        for(int a = 0; a < OBJECTS_TO_INSTANTIATE.Length; a++)
        {
            for(int quantity = 0; quantity < 1000; quantity++)
            {
                var obj = Instantiate(OBJECTS_TO_INSTANTIATE[a], gameElementsContainer);
                obj.SetActive(false);
                objects[a].Add(obj);
            }
        }
    }

    public GameObject GetObject(entity key, Vector2 position)
    {
        foreach(GameObject obj in objects[(int)key])
        {
            if(obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
                obj.transform.position = position;
                return obj;
            }
        }
        return objects[(int)key][Random.Range(0, objects[(int)key].Count)];
    }

    public void Restart()
    {
        foreach(List<GameObject> list in objects)
        {
            foreach(GameObject obj in list)
            {
                obj.SetActive(false);
            }
        }
    }
}
