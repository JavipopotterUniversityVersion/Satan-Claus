using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Container
{
    [SerializeField] CupInfo cupInfo;

    private void Start() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    private void OnStateEnter(GameState state) {
        if(state == GameState.Cooking)
        {
            ResetContainer();
        }
    }

    void OnStateExit(GameState state)
    {
        if (state == GameState.Cooking)
        {
            for(int i = 0; i < numberOfDrops.Length; i++)
            {
                cupInfo.numberOfDrops[i] = numberOfDrops[i];
            }
        }
    }
}
