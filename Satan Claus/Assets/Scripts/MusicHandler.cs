using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private void Start() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    private void OnDestroy() {
        GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
        GameManager.GM.OnStateExit.RemoveListener(OnStateExit);
    }

    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                AudioManager.instance.Stop("MainTheme");
                CheckAudioSource("MenuTheme");
                break;
            case GameState.Cafe:
                CheckAudioSource("MainTheme");
                break;
            case GameState.End:
                AudioManager.instance.Stop("MainTheme");
                CheckAudioSource("CreditsTheme");
                break;
        }
    }

    void OnStateExit(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                AudioManager.instance.Stop("MenuTheme");
                break;
            case GameState.End:
                AudioManager.instance.Stop("CreditsTheme");
                break;
        }
    }

    void CheckAudioSource(string name)
    {
        if(!AudioManager.instance.GetAudioSource(name).isPlaying)
        {
            AudioManager.instance.Play(name);
        }
    }
}
