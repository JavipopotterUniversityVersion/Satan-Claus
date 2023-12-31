using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    Menu,
    MainMenu,
    CookingMenu,
    DialogMenu,
    CleaningMenu,
    CafeSection
}


public class SectionManager : MonoBehaviour
{
    public static SectionManager canvas;
    [SerializeField] List<SectionController> SectionControllerList;

    private void Awake() {

        canvas = this;

        DeactivateAllCanvases();
    }

    private void Start() {
        if(GameManager.GM != null) 
        {
            GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
            GameManager.GM.OnStateExit.AddListener(OnStateExit);
        }

        GameManager.GM.ChangeStateOfGame(GameState.MainMenu);
    }

    void ActivateCanvas(CanvasType desiredType)
    { 
        foreach(SectionController sectionController in SectionControllerList)
        {
            if(sectionController.type == desiredType)
            {
                sectionController.gameObject.SetActive(true);
            }
        }
    }

    void DeactivateCanvas(CanvasType desiredType)
    {
        foreach(SectionController sectionController in SectionControllerList)
        {
            if(sectionController.type == desiredType)
            {
                sectionController.gameObject.SetActive(false);
            }
        }
    }

    void DeactivateAllCanvases()
    {
        foreach(SectionController SectionController in SectionControllerList)
        {
            SectionController.gameObject.SetActive(false);
        }
    }


    void OnStateExit(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                ActivateCanvas(CanvasType.CafeSection);
                DeactivateCanvas(CanvasType.MainMenu);
                break;
            case GameState.Dialog:
                DeactivateCanvas(CanvasType.DialogMenu);
                break;
            case GameState.Cooking:
                DeactivateCanvas(CanvasType.CookingMenu);
                break;
            case GameState.Cleaning:
                DeactivateCanvas(CanvasType.CleaningMenu);
                break;
            case GameState.Paused:
                DeactivateCanvas(CanvasType.Menu);
                break;
        }
    }
    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                DeactivateAllCanvases();
                ActivateCanvas(CanvasType.MainMenu);
                break;
            case GameState.Dialog:
                ActivateCanvas(CanvasType.DialogMenu);
                break;
            case GameState.Cooking:
                ActivateCanvas(CanvasType.CookingMenu);
                break;
            case GameState.Cleaning:
                ActivateCanvas(CanvasType.CleaningMenu);
                break;
            case GameState.Paused:
                ActivateCanvas(CanvasType.Menu);
                break;
        }   
    }

    private void OnDestroy() {
        if(GameManager.GM != null)
        {
            GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
            GameManager.GM.OnStateExit.AddListener(OnStateExit);
        }
    }
}