using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    public bool gameOver;
    public Animation anim;
    private Rigidbody rb;
    private AudioSource playerAudio;
    public float moveSpeed;
    public float jumpForce;
    public AudioClip pickupSound;
    public float xRange;
    public float xRange1;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        //foreach (AnimationState Idle in anim)
        //{
        //    Idle.speed = 0.5f;
        //}
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        Move();
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
            //foreach (AnimationState Run in anim)
            //{
            //    Run.speed = 0.5f;
            //}
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //if (transform.position.z < -354) 
            //{
            //    gameManager.GameOver();
            //}

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    foreach (AnimationState Runtojumpspring in anim)
            //    {
            //        Runtojumpspring.speed = 0.5f;
            //    }

            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //}
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
