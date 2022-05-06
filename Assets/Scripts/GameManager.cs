using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button startButton;
    private int score;
    public bool isGameActive;
    GameObject player;

    void Start()
    {
        
    }
    
    // 
    public void StartGame()
    {
        isGameActive = true;    
        titleScreen.SetActive(false);
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
            gameOverText.gameObject.SetActive(true);
            startButton.gameObject.SetActive(true);
            isGameActive = false;
    }

}
