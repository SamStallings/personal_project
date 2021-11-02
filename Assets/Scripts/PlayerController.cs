using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public float elevForce;
    private float levelModifier = 1.5f;
    private float topLimit = 5.0f;
    private float speed = 10.0f;

    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem sparkParticle;
    public ParticleSystem gearParticle;

    private AudioSource playerAudio;
    public AudioClip explodeSound;
    public AudioClip shootSound;
    public AudioClip elevSound;
    public AudioClip wrenchSound;
    public AudioClip groundSound;

    // Start is called before the first frame
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= levelModifier;
        // Apply a small force at the start of the game
    }

    // Update is called once per frame
    private void Update()
    {
        // While space is pressed and player is low enough, elevate up
        if (Input.GetKey(KeyCode.Space) && gameOver != true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            playerRb.AddForce(Vector3.up * elevForce, ForceMode.Impulse);
        }
        if (transform.position.y > topLimit)
        {
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with enemy, explode, and set gameOver
        if (other.gameObject.CompareTag("Enemy"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        //if player collides with power up, fix robot
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            gearParticle.Play();
            playerAudio.PlayOneShot(wrenchSound, 1.0f);
            Destroy(other.gameObject);
            gearParticle.transform.position = this.transform.position;
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playerAudio.PlayOneShot(groundSound, 1.0f);
        }
    }
}
