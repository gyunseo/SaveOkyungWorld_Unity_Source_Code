using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmenu : MonoBehaviour
{
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ChangetoHelpScene()
    {
        SceneManager.LoadScene("Help");
    }
    public void ChangetoCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitThisGame()
    {
        Application.Quit();
    }
}
