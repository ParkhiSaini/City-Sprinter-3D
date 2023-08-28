using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button Play;
    public Button Quit;
    public Button Controls;
    public GameObject ControlPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlButton()
    {
        ControlPanel.SetActive(true);

    }

    public void Cross()
    {
        ControlPanel.SetActive(false);
    }

    
}
