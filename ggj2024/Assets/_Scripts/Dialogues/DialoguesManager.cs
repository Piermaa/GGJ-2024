using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string Tag;
    public Lines DialogueLines;
    public bool Written;
}

public class DialoguesManager : MonoBehaviour
{
    public static DialoguesManager Instance;
    [SerializeField] private Dialogue[] _dialogues;
    [SerializeField] private Dialogues _dialogue;
    private Dictionary<string,Dialogue> _dialoguesDictionary= new();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        foreach (Dialogue dial in _dialogues)
        {
            _dialoguesDictionary.Add(dial.Tag, dial);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var dialogue = _dialogues[Random.Range(0, _dialogues.Length)];
            print(dialogue);
            var dialogues = dialogue.DialogueLines;
            print(dialogues);
            _dialogue.SetDialogue(dialogues);
        }
    }

    public void SetDialogue(string key)
    {
        _dialogue.SetDialogue(_dialoguesDictionary[key].DialogueLines);
    }
}
