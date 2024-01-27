using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string dialogueTag;
    [SerializeField] private bool isPlayerDialogue=true;
    public void StartDialogue()
    {
        if (isPlayerDialogue)
        {
            DialoguesManager.PlayerInstance.SetDialogue(dialogueTag);
        }
        else
        {
            DialoguesManager.NarratorInstance.SetDialogue(dialogueTag);
        }
    }
}
