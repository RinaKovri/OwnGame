using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    public bool gameOver = false;
    private float leftBound = -28;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        // If object goes off screen that is not the background, destroy it
        if (transform.position.z < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z < leftBound && !gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z < leftBound && !gameObject.CompareTag("PickUp"))
        {
            Destroy(gameObject);
        }
    }
}

