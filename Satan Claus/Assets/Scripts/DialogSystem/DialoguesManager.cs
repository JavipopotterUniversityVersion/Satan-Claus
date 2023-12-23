using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class DialoguesManager : MonoBehaviour
{
    public static DialoguesManager dialoguesManager;
    public Animator dialogueUiAn;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI text;
    public TextMeshProUGUI choice1;
    public TextMeshProUGUI choice2;
    public GameObject[] img;
    [SerializeField] string[] img_sources_keys;
    [SerializeField] Sprite[] img_sources;
    Dictionary<string, Sprite> img_sources_dict = new Dictionary<string, Sprite>();
    public GameObject UIpointer;
    public string[] choices;
    [SerializeField] GameObject storyTeller;
    bool next;
    public bool skipDialog;
    bool skipText;
    private Coroutine executeDialogCoroutine;
    public InputActionReference pass;
    public UnityEvent<bool> OnDialogNotPerforming;
    public UnityEvent servedEvent;
    string beep = "mic_beep";
    bool isPerforming = false;
    Animator _talkingCharacter;
    Animator talkingCharacter
    {
        get
        {
            return _talkingCharacter;
        }
        set
        {
            if(_talkingCharacter != null)
            {
                _talkingCharacter.SetBool("turn", false);
            }
            value?.SetBool("turn", true);

            _talkingCharacter = value;
        }
    }

    private void Awake() {
        dialoguesManager = this;
        servedEvent = new UnityEvent();
        pass.action.performed += OnPassActionPerformed;
        for(int i = 0; i < img_sources_keys.Length; i++)
        {
            img_sources_dict.Add(img_sources_keys[i], img_sources[i]);
        }
    }

    private void OnEnable() {
        pass.action.Enable();
    }

    private void OnDisable() {
        pass.action.Disable();
    }

    private void OnDestroy() {
        pass.action.performed -= OnPassActionPerformed;
    }

    void OnPassActionPerformed(InputAction.CallbackContext context)
    {
        if(next)
        {
            skipText = true;
        }
        next = true;
    }

    public void ExecuteDialog(string dialog)
    {
        executeDialogCoroutine = StartCoroutine(_ExecuteDialog(dialog));
    }

    public void ExecuteDialogViaKey(string key)
    {
        if(executeDialogCoroutine != null) StopCoroutine(executeDialogCoroutine);
        executeDialogCoroutine = StartCoroutine(_ExecuteDialog(Dialogues.dialogues.texts[key]));
    }

    IEnumerator _ExecuteDialog(string key)
    {
        isPerforming = true;

        GameManager.GM.ChangeStateOfGame(GameState.Dialog);
        OnDialogNotPerforming?.Invoke(false);
        text.text = "";

        pass.action.Enable();

        if(key == "")
        {
            GameManager.GM.ChangeStateOfGame(GameState.Cafe);
            yield break;
        }

        string[] arguments = key.Split("*");

        foreach(string line in arguments)
        {
            next = false;
            skipText = false;
            UIpointer.SetActive(false);

            if(line.Contains("[SC]"))
            {
                ExecuteDialog(Dialogues.dialogues.shortcuts[line.Split("[SC]")[1]]);
                while (isPerforming) yield return null;
                continue;
            }

            if(line.Contains("-choice-"))
            {
                GameObject firstChoice = choice1.transform.parent.gameObject;

                choices = key.Split("-choice-");
                choice1.transform.parent.gameObject.SetActive(true);
                choice2.transform.parent.gameObject.SetActive(true);
                choice1.text = choices[1].Split(">>")[0];
                choice2.text = choices[2].Split(">>")[0];
                break;
            }

            if(line.Contains("[VOICE]"))
            {
                beep = line.Split("[VOICE]")[1];
                continue;
            }

            if(line.Contains("[TXT]"))
            {
                ExecuteDialog(Dialogues.dialogues.texts[line.Split("[TXT]")[1]]);
                break;
            }

            if(line.Contains("<Event>"))
            {
                // while(!Input.GetKeyDown(KeyCode.Space)) yield return null;
                SceneManager.LoadScene(line.Split("<Event>")[1], LoadSceneMode.Single);
                break;
            }

            if(line.Contains("[NOCINE]"))
            {
                continue;
            }

            if(line.Contains("[END]"))
            {
                OnDialogNotPerforming?.Invoke(true);
                GameManager.GM.ChangeStateOfGame(GameState.Cafe);
                break;
            }

            if(line.Contains("[BREAK]"))
            {
                break;
            }

            if(line.Contains("[SERVED]"))
            {
                servedEvent?.Invoke();
                continue;
            }

            if(line.Contains("[IMG]"))
            {
                if(line.Split("[IMG]")[1] == "none")
                {
                    storyTeller.SetActive(false);
                    continue;
                }
                continue;
            }

            if(line.Contains("[GM]"))
            {
                GameManager.GM.Invoke(line.Split("[GM]")[1], 0);
                continue;
            }

            if(line.Contains("[NAME]"))
            {
                Name.text = line.Split("[NAME]")[1];
                continue;
            }

            if(line.Contains("ClImg"))
            {
                foreach(GameObject img in img)
                {
                    img.SetActive(false);
                }
                continue;
            }

            if(line.Contains("[Img]"))
            {
                string sprite = line.Split("[Img]")[1];
                Transform img_transform = img[int.Parse(line.Split(")")[0])].transform;
                if(sprite != "")
                {
                    img_transform.gameObject.SetActive(true);
                    img_transform.GetComponentInChildren<Image>().sprite = img_sources_dict[sprite];
                }
                else
                {
                    img_transform.gameObject.SetActive(false);
                }
                continue;
            }

            if(line.Contains("[AnTr]"))
            {
                Transform img_transform = img[int.Parse(line.Split(")")[0])].transform;
                img_transform.GetComponentInChildren<Animator>().SetTrigger(line.Split("[An]")[1]);
            }

            if(line.Contains("[AnBool]"))
            {
                Transform img_transform = img[int.Parse(line.Split(")")[0])].transform;
                img_transform.GetComponentInChildren<Animator>().SetBool(line.Split("[An]")[1], bool.Parse(line.Split("[An]")[2]));
            }

            if(line.Contains("[TALKING]"))
            {
                talkingCharacter = img[int.Parse(line.Split(")")[0])].transform.GetComponentInParent<Animator>();
                continue;
            }

            if(line.Contains("[NOTGAME]"))
            {
                continue;
            }

            if(line.Contains("[HIDE]"))
            {
                Name.text = " ";
                text.transform.parent.gameObject.SetActive(false);
                continue;
            }

            if(line.Contains("[UNHIDE]"))
            {
                text.transform.parent.gameObject.SetActive(true);
                continue;
            }

            if(line.Contains("[Wait]"))
            {
                if(!skipDialog)
                    yield return new WaitForSecondsRealtime(float.Parse(line.Split("[Wait]")[1]));
                else
                    yield return new WaitForSecondsRealtime(float.Parse(line.Split("[Wait]")[1]) / 10);

                continue;
            }

            if(line.Contains("[MUSIC]"))
            {
                AudioManager.instance.Play(line.Split("[MUSIC]")[1]);
                continue;
            }

            if(line.Contains("[QUIT]"))
            {
                Application.Quit();
                continue;
            }

            text.text = "";

            if(talkingCharacter != null)
            {
                talkingCharacter.SetBool("talking", true);
            }

            foreach(char character in line)
            {
                text.text += character;
                AudioManager.instance.PlayOneShot(beep);

                if(!skipDialog)
                {
                    if(!skipText)
                    {
                        yield return new WaitForSecondsRealtime(0.015f);
                    }
                }
            }

            if(talkingCharacter != null)
            {
                talkingCharacter.SetBool("talking", false);
            }

            UIpointer.SetActive(true);
            next = false;
            skipText = false;
            while(!(skipDialog || next)) {yield return null;}
        }
        skipDialog = false;

        isPerforming = false;
    }

    public void ExecuteChoice(int num)
    {
        choice1.transform.parent.gameObject.SetActive(false);
        choice2.transform.parent.gameObject.SetActive(false);
        ExecuteDialog(choices[num].Split(">>")[1]);
    }
}
