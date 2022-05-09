using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    public Animation anim;
    Rigidbody rb;
    private AudioSource playerAudio;
    public AudioClip pickupSound;
    public Vector3 jump;

    public float moveSpeed;
    public float jumpForce;
    public float xRange;
    public float xRange1;

    public int pointValue;

    public bool gameOver;
    public bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        anim = GetComponent<Animation>();
        anim.Play("Idle");
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionStay()
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
        }
    }


    void Move()
    {
        if (gameManager.isGameActive)
        {
            
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                anim.Play("Runtojumpspring");
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        if (isGrounded) {
            //anim.Play("Run");
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
    }
}
