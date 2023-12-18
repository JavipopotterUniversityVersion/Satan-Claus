using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] ClientBehaviour[] clients;
    int currentClient = 0;

    private void Start() {
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        foreach(ClientBehaviour client in clients)
        {
            client.transform.position = transform.position;
        }

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
        if(currentClient == clients.Length)
        {
            GameManager.GM.ChangeStateOfGame(GameState.End);
            yield break;
        }
        yield return new WaitForSecondsRealtime(5);
        clients[currentClient].gameObject.SetActive(true);
    }
}
