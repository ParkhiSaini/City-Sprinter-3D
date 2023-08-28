using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score=0;
    private bool playerReady=false;
    public Button MainMenu;

    public TextMeshProUGUI GameOverText;

    void Start()
    {
        Time.timeScale=1;
    }
    public void UpdateScore(int newScore)
    {
        score=newScore;
        UpdateScoreUI();
    }

    private void UpdateScoreUI ()
    {
        scoreText.text ="Score:" + score.ToString();
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        
        MainMenu.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
