using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string Tag;
    public bool Written;
    public Lines DialogueLines;
}

public class DialoguesManager : MonoBehaviour
{
    public static DialoguesManager Instance;
    [SerializeField] private Dialogues _dialogue;
    [SerializeField] private Dialogue[] _dialogues;
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
        Dialogue currentDialogue = _dialoguesDictionary[key];

        if (!currentDialogue.Written)
        {
            _dialogue.SetDialogue(_dialoguesDictionary[key].DialogueLines);
            currentDialogue.Written = true;
        }

    }
}
