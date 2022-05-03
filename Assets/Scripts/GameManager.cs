using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public Button startButton;
    private int score;
    public bool isGameActive;

    // 
    public void StartGame(int difficulty)
    {
        isGameActive = true;    
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }


    // 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void GameOver()
    {
        startButton.gameObject.SetActive(true);
        isGameActive = false;
    }

}
