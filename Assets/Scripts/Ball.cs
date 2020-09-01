using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    bool hasStarded = false;

    // Cached components reference
    AudioSource myAudioSource;
// Vector 2 represents the 2D vectors and points
    Vector2 paddleToBallVector;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void handleBallFixedToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }

    private void launchBallMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarded = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (hasStarded) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

    void Update()
    {
        if (!hasStarded) {
            handleBallFixedToPaddle();
            launchBallMouseClick();
        }
    }
}
