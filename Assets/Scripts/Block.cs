using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    
    // Cachable reference
    Level level;

    private void Start() {
       level =  FindObjectOfType<Level>();
       level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        FindObjectOfType<GamesStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
