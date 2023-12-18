using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    MainMenu,
    Cafe,
    Dialog,
    Cooking,
    Cleaning,
    stateHolder,
    End
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    GameState stateHolder;
    GameState gameState;
    public GameState newState;
    [HideInInspector] public UnityEvent<GameState> OnStateEnter;
    [HideInInspector] public UnityEvent<GameState> OnStateExit;

    private void Awake() {
        GM = this;
        OnStateEnter = new UnityEvent<GameState>();
        OnStateExit = new UnityEvent<GameState>();
    }

    private void Start() {
        AudioManager.instance.Play("InGame");
    }

    public void ChangeStateOfGame(GameState newState)
    {
        this.newState = newState;
        OnStateExit?.Invoke(gameState);

        switch(newState)
        {
            case GameState.stateHolder:
                ChangeStateOfGame(stateHolder);
                break;
        }

        OnStateEnter?.Invoke(newState);

        stateHolder = gameState;
        gameState = newState;
    }
}