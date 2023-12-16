using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    MainMenu,
    Cutscene,
    Cafe,
    Talking,
    Cooking,
    Cleaning
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    GameState stateHolder;
    public GameState gameState;
    [HideInInspector] public UnityEvent<GameState> OnStateEnter;
    [HideInInspector] public UnityEvent<GameState> OnStateExit;

    private void Awake() {
        GM = this;
    }

    public void ChangeStateOfGame(GameState newState)
    {
        OnStateEnter?.Invoke(newState);

        gameState = newState;
    }
}