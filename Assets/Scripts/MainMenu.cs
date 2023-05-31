using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }

    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
        CollCaunt.count = 0;
    }
}
