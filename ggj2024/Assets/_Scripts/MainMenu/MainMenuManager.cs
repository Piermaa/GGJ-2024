using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject creditsPanel;

    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OpenMainMenuPanel()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}