using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Dialogues : MonoBehaviour
{
    public static Dialogues dialogues;
    public Dictionary<string, string> texts = new Dictionary<string,string>();
    public List<string> textKeys;
    public TextAsset file;
    string[] fileDivisons;
    public TextAsset shortcutsFile;
    public Dictionary<string, string> shortcuts = new Dictionary<string,string>();

    private void Awake() {
        dialogues = this;
        fileDivisons = file.text.Split("___");
        foreach(string line in fileDivisons)
        {
            string[] a = line.Split("//");
            texts.Add(a[0].Replace("\n", ""), a[1].Replace("\n", ""));
        }
        foreach(string key in texts.Keys)
        {
            textKeys.Add(key);
        }
        foreach(string a in texts.Keys)
        {
            textKeys.Add(a);
        }

        foreach(string line in shortcutsFile.text.Split("__"))
        {
            string[] a = line.Split("//");
            shortcuts.Add(a[0].Replace("\n", ""), a[1].Replace("\n", ""));
        }

        foreach(string key in shortcuts.Keys)
        {
            print(key);
        }
    }
}
