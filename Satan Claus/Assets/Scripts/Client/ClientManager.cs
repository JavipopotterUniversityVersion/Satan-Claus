using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] ClientBehaviour[] clients;
    int currentClient = 0;

    private void OnEnable() {
        currentClient = 0;
        StartCoroutine(SetNewClient());
    }

    private void Start() {
        FindObjectOfType<RubbishBin>(true).OnRubbishCleaned.AddListener(OnRubbishCleaned);

        foreach(ClientBehaviour client in clients)
        {
            client.transform.position = transform.position;
        }
    }

    void OnRubbishCleaned()
    {
        currentClient++;
        StartCoroutine(SetNewClient());
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
