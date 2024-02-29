using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPopup : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadGame()
    {

    }

    public void GameSetting()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
