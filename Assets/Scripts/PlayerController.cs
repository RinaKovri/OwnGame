using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    public Animator anim;
    private Rigidbody rb;
    private AudioSource playerAudio;
    public float moveSpeed;
    //public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;
    //public AudioClip attackSound;
    //public AudioClip deadSound;

    // Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    playerAudio = GetComponent<AudioSource>();
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObj();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("PickUp"))
    //    {
    //        Destroy(other.gameObject);
    //        //explosionParticle.Play();
    //    }

    //    if (other.gameObject.CompareTag("Obstacle"))
    //    {
    //        anim.SetTrigger("dead");
    //        Debug.Log("Game Over");
    //        gameOver = true;
    //    }
    //}
    void MoveObj()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
