using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int breakableBlocks; // For debug purpose
    
    // Cache ref
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks() {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;

        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
