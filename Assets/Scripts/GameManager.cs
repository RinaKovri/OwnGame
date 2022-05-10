using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public GameObject titleScreen;
    public GameObject restartScreen;
    public Button startButton;
    public Button restartButton;
    private int score;
    public bool isGameActive;

    void Start()
    {
        
    }
    
    // 
    public void StartGame()
    {
        isGameActive = true;    
        titleScreen.SetActive(false);
        restartScreen.SetActive(false);
        score = 0;
        UpdateScore(0);
    }
    // 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void GameOver()
    {
         winText.gameObject.SetActive(true);
         isGameActive = false;
    }
    public void RestartGame()
    {
        restartScreen.SetActive(true);
        isGameActive = false;
    }

}
