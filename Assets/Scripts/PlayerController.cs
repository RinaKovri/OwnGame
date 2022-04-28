using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    public Animator anim;
    private Rigidbody rb;
    private AudioSource playerAudio;
    //public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;
    //public AudioClip attackSound;
    //public AudioClip deadSound;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("attack");
            //dirtParticle.Stop();
            //playerAudio.PlayOneShot(attackSound, 1.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            anim.SetTrigger("pickUp");
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            anim.SetBool("dead", true);
            //explosionParticle.Play();
            //dirtParticle.Stop();
            Debug.Log("Game Over");
            gameOver = true;
            //playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
