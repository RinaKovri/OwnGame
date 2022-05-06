using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetStart);
    }

    // When a button was clicked, call the StartGame() method
     
    
    void SetStart()
    {
        Debug.Log(button.gameObject.name + " was clicked ");
        gameManager.StartGame();
    }



}
