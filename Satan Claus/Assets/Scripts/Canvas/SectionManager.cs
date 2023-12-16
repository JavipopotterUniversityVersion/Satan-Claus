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
}


public class SectionManager : MonoBehaviour
{
    public static SectionManager canvas;
    [SerializeField] List<SectionController> SectionControllerList;

    private void Awake() {

        canvas = this;

        SectionControllerList = GetComponentsInChildren<SectionController>().ToList();
        DeactivateAllCanvases();
    }

    private void Start() {
        if(GameManager.GM != null) 
        {
            GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
            GameManager.GM.OnStateExit.AddListener(OnStateExit);
        }
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
                DeactivateCanvas(CanvasType.MainMenu);
                break;
            case GameState.Dialog:
                DeactivateCanvas(CanvasType.DialogMenu);
                break;
            case GameState.Cooking:
                DeactivateCanvas(CanvasType.CookingMenu);
                break;
        }
    }
    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                ActivateCanvas(CanvasType.MainMenu);
                break;
            case GameState.Dialog:
                ActivateCanvas(CanvasType.DialogMenu);
                break;
            case GameState.Cooking:
                ActivateCanvas(CanvasType.CookingMenu);
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