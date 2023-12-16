using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StateChangerButton : MonoBehaviour
{
    [SerializeField] GameState state;
    private void Awake() {
        GetComponent<Button>().onClick.AddListener(ChangeState);
    }

    void ChangeState()
    {
        GameManager.GM.ChangeStateOfGame(state);
    }

    void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ChangeState);
    }
}
