using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    void SetStart()// When a button was clicked, call the StartGame() method
    {
        Debug.Log(button.gameObject.name + " was clicked ");
        gameManager.StartGame();
    }
}
