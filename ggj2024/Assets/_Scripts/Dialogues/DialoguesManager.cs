using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string Tag;
    public string EventTag;
    public bool Written;
    public string[] DialogueLines;
}

public class DialoguesManager : MonoBehaviour
{
    public static DialoguesManager NarratorInstance;
    public static DialoguesManager PlayerInstance;
    [SerializeField] private bool isPlayer;
    [SerializeField] private TextWritter _dialogue;
    [SerializeField] private Dialogue[] _dialogues;
    private Dictionary<string,Dialogue> _dialoguesDictionary= new();

    private void Awake()
    {
        if (!isPlayer)
        {
            if (NarratorInstance == null)
            {
                NarratorInstance = this;
            }
        }
        else
        {
            if (PlayerInstance == null)
            {
                PlayerInstance = this;
            }
        }
       

        foreach (Dialogue dial in _dialogues)
        {
            _dialoguesDictionary.Add(dial.Tag, dial);
        }

        TextWritter.OnDialogueFinish += SetDialogue;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var dialogue = _dialogues[Random.Range(0, _dialogues.Length)];
            SetDialogue(dialogue.Tag);
        }
    }

    public void SetDialogue(string key)
    {
        Dialogue currentDialogue = _dialoguesDictionary[key];

        if (!currentDialogue.Written && _dialogue.SetDialogue(_dialoguesDictionary[key], isPlayer))
        {  
            _dialoguesDictionary[key].Written = true;
        }
    }
}
