using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    public static event Action<int> OnTimeElapsed;

    [SerializeField] float startingTime;
    [SerializeField] TextMeshProUGUI timerText;

    private float currentTime;

    private int minutes;
    private int seconds;    

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(currentTime < 0.1)
        {
            SceneManagement.Instance.LoadScene(0);
        }
    }
}
