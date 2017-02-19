using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 15.0f;

    private Rigidbody rb;

    private int score;

    [SerializeField]
    private AudioSource playerTalk;
    [SerializeField]
    private AudioSource playerCollect;
    [SerializeField]
    private AudioClip collectSound;
    [SerializeField]
    private AudioClip deadSound;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);

        rb.AddForce(movement);
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Box") {
            score++;
            speed++;
            if (playerCollect != null && collectSound != null) {
                playerCollect.PlayOneShot(collectSound);       
            }
            GameController.intstance.ChangeScore(score);
            Die(collision);
        }
    }


    private void OnCollisionStay(Collision collision) {

        if (collision.gameObject.tag == "Box") {
            Die(collision);
        }
    }

    private void Die(Collision collision) {
        BoxStates colState = collision.gameObject.GetComponent<BoxScript>().State;
        if (colState == BoxStates.red) {
            collision.gameObject.SetActive(false);
            if (playerTalk != null && deadSound != null) {
                playerCollect.clip = deadSound;
                playerCollect.Play();
            }
            GameController.intstance.EndGame();

        }
    }
}
