using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    public bool gameOver = false;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (Input.GetKey(KeyCode.RightArrow) && !gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))   
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound && !gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound && !gameObject.CompareTag("PickUp"))
        {
            Destroy(gameObject);
        }
    }
}
