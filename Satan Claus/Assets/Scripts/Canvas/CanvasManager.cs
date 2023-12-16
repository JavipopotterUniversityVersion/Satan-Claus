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


public class CanvasManager : MonoBehaviour
{
    public static CanvasManager canvas;
    List<CanvasController> canvasControllerList;

    private void Awake() {

        if(canvas == null) {canvas = this;} else {Destroy(gameObject);}

        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
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
        canvasControllerList.Find(canvas => canvas.type == desiredType).gameObject.SetActive(true);
    }

    void DeactivateCanvas(CanvasType desiredType)
    {
        canvasControllerList.Find(canvas => canvas.type == desiredType).gameObject.SetActive(false);
    }

    void DeactivateAllCanvases()
    {
        foreach(CanvasController canvasController in canvasControllerList)
        {
            canvasController.gameObject.SetActive(false);
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