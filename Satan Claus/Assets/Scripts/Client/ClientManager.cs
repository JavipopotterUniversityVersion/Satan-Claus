using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] ClientBehaviour[] clients;
    int currentClient = 0;

    private void Start() {
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        StartCoroutine(SetNewClient());
    }

    void OnRubbishCleaned()
    {
        currentClient++;
        clients[currentClient].gameObject.SetActive(true);
    }

    void OnStateExit(GameState state)
    {
        switch(state)
        {
            case GameState.Cleaning:
                OnRubbishCleaned();
                StartCoroutine(SetNewClient());
                break;
        }
    }

    IEnumerator SetNewClient()
    {
        yield return new WaitForSecondsRealtime(5);
        clients[currentClient].gameObject.SetActive(true);
        clients[currentClient].transform.position = transform.position;
    }
}
