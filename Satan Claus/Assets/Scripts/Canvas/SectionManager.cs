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
    CleaningMenu
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
        SectionControllerList.Find(canvas => canvas.type == desiredType).gameObject.SetActive(true);
    }

    void DeactivateCanvas(CanvasType desiredType)
    {
        SectionControllerList.Find(canvas => canvas.type == desiredType).gameObject.SetActive(false);
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
       
    }
    void OnStateEnter(GameState state)
    {
        
    }

    private void OnDestroy() {
        if(GameManager.GM != null)
        {
            GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
            GameManager.GM.OnStateExit.AddListener(OnStateExit);
        }
    }
}