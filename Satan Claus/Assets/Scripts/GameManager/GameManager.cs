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
    Cooking
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public Transform backGrounds;
    public GameObject gameElementsContainer;
    [SerializeField] int _money = 0;
    public int money
    {
        get{return _money;}
        set{
            _money = value;
        }
    }
    GameState stateHolder;
    public GameState gameState;
    [HideInInspector] public UnityEvent OnStartLevel;
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