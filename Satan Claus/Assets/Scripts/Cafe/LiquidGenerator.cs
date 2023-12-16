using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Container))]
public class LiquidGenerator : DropGenerator
{
    Container container;
    [SerializeField] int minDropAmount;
    [SerializeField] TypeOfDrop typeOfDrop;

    private void Awake() {
        container = GetComponent<Container>();
    }

    private void Update() {
        if(container.numberOfDrops[(int) typeOfDrop] < minDropAmount)
        {
            GenerateDrop();
        }
    }
}
