using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfDrop
{lava, souls, salt,  virginBlood}

public class Drop : MonoBehaviour
{
    
    [SerializeField] TypeOfDrop _type;
    Container container;
    TypeOfDrop type
    {
        get{return _type;}
        set
        {
            if(container != null)
                container.numberOfDrops[(int) _type]--;
                container.numberOfDrops[(int) value]++;
            _type = value;
        }
    }
    
    private void OnTriggerEnter2D(Collider other) {
        if(other.TryGetComponent(out Container container))
        {
            this.container = container;
            container.numberOfDrops[(int) type]++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other == container)
        {
            container = null;
        }
    }
}