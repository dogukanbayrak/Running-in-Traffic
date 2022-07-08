using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("chapterOne");
    }


    public void OnApplicationQuit()
    {
        Application.Quit();
    }













}
