using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueStarter))]
public class DialogueStarterOnTriggerEnter: OnPlayerTriggerEnter
{
    private DialogueStarter _dialogueStarter;

    private void Awake()
    {
        _dialogueStarter = GetComponent<DialogueStarter>();
    }

    protected override void Trigger(GameObject playerObject)
    {
        _dialogueStarter.StartDialogue();
    }
}
