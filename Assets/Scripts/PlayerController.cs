using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    public Animator anim;
    Rigidbody rb;
    private AudioSource playerAudio;
    public AudioClip pickupSound;
    public AudioClip fallSound;
    public AudioClip jumpSound;
    public AudioClip winSound;
    public AudioClip crashSound;
    public AudioClip finishSound;

    public float moveSpeed;
    public float xRange;
    public float xRange1;

    public int pointValue;

    public bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = player.transform.position.y < 0.15; //to define where is the ground
        if (gameManager.isGameActive)
        {
            Move();
            float horizontalInput = Input.GetAxis("Horizontal");
            if (isGrounded)
            {
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
            }


            //make the Player not go out the boards of the road
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x < xRange1)
            {
                transform.position = new Vector3(xRange1, transform.position.y, transform.position.z);
            }
            if (transform.position.y < 0)//stop the game when the player falls off the road
            {
                playerAudio.PlayOneShot(fallSound, 1.0f);
                gameManager.isGameActive = false;
                gameManager.restartScreen.SetActive(true);
            }
        }
    }


    void Move()//Player's moving
    {
        if (gameManager.isGameActive)
        {

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//Player's jumping
            {
                isGrounded = false;
                anim.SetTrigger("Jump");
                rb.AddForce(new Vector3(0, 600, 0));
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
        if (isGrounded)//turn on Run animation every time when the Player is on the ground
        {
            anim.SetBool("Run", true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))//picking up the PickUps
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(pointValue);
            playerAudio.PlayOneShot(pickupSound, 1.0f);
        }
        if (other.gameObject.CompareTag("Obstacle"))//stop the game when the Player collides with obstacles
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.restartScreen.SetActive(true);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        if (other.gameObject.CompareTag("Win"))//stop the level when the Player reaches the end of the road
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.nextLevelScreen.SetActive(true);
            playerAudio.PlayOneShot(winSound, 2.0f);
        }
        if (other.gameObject.CompareTag("Finish"))//stop the game when the Player reaches the end of the road
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.winScreen.gameObject.SetActive(true);
            playerAudio.PlayOneShot(finishSound, 2.0f);
        }
    }
}
