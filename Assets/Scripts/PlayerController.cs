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
        isGrounded = player.transform.position.y < 0.15;
        if (gameManager.isGameActive)
        {
            Move();
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
       
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
            if (transform.position.x < xRange1)
        {
            transform.position = new Vector3(xRange1, transform.position.y, transform.position.z);
        }
            if(transform.position.y < 0)
            {
                gameManager.isGameActive = false;
                gameManager.restartScreen.SetActive(true);
            }
        }
    }


    void Move()
    {
        if (gameManager.isGameActive)
        {
            
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                anim.SetTrigger("Jump");
                rb.AddForce(new Vector3(0, 500, 0));
            }
        }
        if (isGrounded)
        {
            anim.SetBool("Run", true);
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(pointValue);
            playerAudio.PlayOneShot(pickupSound, 1.0f);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.restartScreen.SetActive(true);
        }
        if (other.gameObject.CompareTag("Win"))
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.nextLevelScreen.SetActive(true);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            anim.SetBool("Run", false);
            gameManager.isGameActive = false;
            gameManager.winText.gameObject.SetActive(true);
        }
    }
}
