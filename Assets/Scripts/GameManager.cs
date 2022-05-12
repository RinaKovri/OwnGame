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
    public GameObject nextLevelScreen;
    public Button startButton;
    public Button restartButton;
    public Button nextLevelButton;

    private int score;
    public int level;

    public bool isGameActive;

    void Start()
    {
        
    }
    
    
    public void StartGame()//when the start button is clicked
    {
        isGameActive = true;    
        titleScreen.SetActive(false);
        score = 0;
        UpdateScore(0);
    }
    
    public void UpdateScore(int scoreToAdd)//the score's updating
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void NextLevel()// load the nextlevel
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameOver()//when the Player collides with obstacles or falls off the road
    {
         winText.gameObject.SetActive(true);
         isGameActive = false;
    }
    public void RestartGame()//when the restart button is clicked
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
