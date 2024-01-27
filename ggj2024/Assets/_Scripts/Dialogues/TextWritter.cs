using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWritter : MonoBehaviour
{
    public static Action<string> OnDialogueFinish;

    private bool isWritting = false;

    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float _textSpeed = 0.1f;
    [SerializeField] private float _timeBetweenLines = 1;
    [SerializeField] private AudioClip _playerSpeak;
    [SerializeField] private AudioClip _narratorSpeak;
    [SerializeField] private bool isPlayer;

    private AudioSource speakSource;
    private AudioClip currettSpeakClip;
    private Dialogue currentDialogue;
    private string[] currentLines;

    private int _dialogueIndex;
    private int _linesIndex;


    void Start()
    {
        speakSource = GetComponent<AudioSource>();
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

        if (isWritting && speakSource.isPlaying)
        {
            speakSource.pitch = UnityEngine.Random.Range(.95f,1.1f);
            speakSource.Play();
        }
        else
        {
            speakSource.Stop();
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
            isWritting = false;
            OnDialogueFinish?.Invoke(currentDialogue.EventTag);
        }
    }

    public void SetNextDialogue()
    {
        textComponent.text = string.Empty;
        _dialogueIndex++;
        _linesIndex = 0;
        StartDialogue();
    }

    public bool SetDialogue(Dialogue newDialogue, bool isPlayer)
    {
        if (!isWritting)
        {
            currentDialogue = newDialogue;
            currentLines = newDialogue.DialogueLines;
            StartDialogue();
            isWritting = true;

            speakSource.clip = isPlayer ? _playerSpeak : _narratorSpeak;
        }

        return isWritting;
    }

}
