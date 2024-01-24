using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [System.Serializable]
    public struct Lines
    {
        [SerializeField] public Transform _newPosition;
        [SerializeField] public string[] _lines;
    }

    [SerializeField] private Lines[] _dialogues;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float _textSpeed = 0.1f;
    private int _dialogueIndex;
    private int _linesIndex;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == _dialogues[_dialogueIndex]._lines[_linesIndex])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = _dialogues[_dialogueIndex]._lines[_linesIndex];
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
        foreach (char c in _dialogues[_dialogueIndex]._lines[_linesIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    void NextLine()
    {
        if (_linesIndex < _dialogues[_dialogueIndex]._lines.Length - 1)
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
        _linesIndex = 0;
        StartDialogue();
    }
}
