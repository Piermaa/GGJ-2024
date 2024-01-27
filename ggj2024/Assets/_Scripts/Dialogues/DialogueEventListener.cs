using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEventListener : MonoBehaviour
{
    [SerializeField] private string eventTag;
    [SerializeField] private UnityEvent onTextFinish;

    private void Awake()
    {
        TextWritter.OnDialogueFinish += OnDialogueFinish;
    }

    private void OnDialogueFinish(string tag)
    {
        print(tag+"Finished");

        if (tag==eventTag)
        {
            onTextFinish.Invoke();
            print("Listened to: " + tag + "Dialogue event");
        }
    }
}
