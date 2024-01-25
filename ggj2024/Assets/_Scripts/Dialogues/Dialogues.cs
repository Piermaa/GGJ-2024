using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public struct Lines
{
    [SerializeField] public Transform _newPosition;
    [SerializeField] public string[] _lines;
}

public class Dialogues : MonoBehaviour
{
    [SerializeField] private Lines[] _dialogues;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float _textSpeed = 0.1f;

    private Lines _currentDialogue;

    private int _dialogueIndex;
    private int _linesIndex;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == _currentDialogue._lines[_linesIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = _currentDialogue._lines[_linesIndex];
            }
        }
    }

    public void StartDialogue()
    {
        _linesIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _currentDialogue._lines[_linesIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    void NextLine()
    {
        if (_linesIndex < _currentDialogue._lines.Length - 1)
        {
            _linesIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            textComponent.text = string.Empty;
        }
    }

    public void SetNextDialogue()
    {
        textComponent.text = string.Empty;
        _dialogueIndex++;
        _currentDialogue= _dialogues[_dialogueIndex];
        _linesIndex = 0;
        StartDialogue();
    }

    public void SetDialogue(Lines newDialogue)
    {
        _currentDialogue = newDialogue;
        StartDialogue();
    }

}
