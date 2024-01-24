using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(this);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        //Agregar el código para poder testearlo en el Editor
        Application.Quit();
        Debug.Log("Has quitted");
    }
}
