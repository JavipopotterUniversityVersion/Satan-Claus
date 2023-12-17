using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfDrop
{lava, souls, salt,  virginBlood}

public class Drop : MonoBehaviour
{
    [SerializeField] TypeOfDrop _type;
    float timer = 3;
    Container container;
    public TypeOfDrop type
    {
        get{return _type;}
        set
        {
            if(container != null)
            {
                container.numberOfDrops[(int) _type]--;
                container.numberOfDrops[(int) value]++;
            }
            _type = value;
        }
    }
    
    private void Update() {
        if(timer <= 0)
        {
            timer = 3;
            gameObject.SetActive(false);
        }

        if(container == null)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent(out Container container))
        {
            this.container = container;
            container.numberOfDrops[(int) type]++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(container != null)
        {
            if(other.gameObject == container.gameObject)
            {
                container.numberOfDrops[(int) type]--;
                container = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out Drop drop) && type == TypeOfDrop.lava)
        {
            if(drop.type == TypeOfDrop.souls)
            {
                type = TypeOfDrop.souls;
            }
        }
    }
}