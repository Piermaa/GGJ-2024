using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float _textSpeed = 0.1f;
    [SerializeField] private float _timeBetweenLines = 1;

    private string[] currentLines;

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
            if (textComponent.text == currentLines[_linesIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentLines[_linesIndex];
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
        foreach (char c in currentLines[_linesIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }

        yield return new WaitForSeconds(_timeBetweenLines);

        NextLine();
    }

    void NextLine()
    {
        if (_linesIndex < currentLines.Length - 1)
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

    public void SetDialogue(string[] newDialogue)
    {
        currentLines = newDialogue;
        StartDialogue();
    }

}
