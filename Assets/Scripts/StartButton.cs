using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    public Button button;
    public Button restartButton;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetStart);
        button.onClick.AddListener(SetRestart);
    }

    // When a button was clicked, call the StartGame() method
     
    
    void SetStart()
    {
        Debug.Log(button.gameObject.name + " was clicked ");
        gameManager.StartGame();
    }

    void SetRestart()
    {
        Debug.Log(restartButton.gameObject.name + "was clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
