using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string dialogueTag;

    public void StartDialogue()
    {
        DialoguesManager.Instance.SetDialogue(dialogueTag);
    }
}
