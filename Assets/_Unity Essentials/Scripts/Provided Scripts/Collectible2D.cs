using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    public AudioClip collectSound;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
         // Check if the other object has a PlayerController2D component
        if (other.GetComponent<PlayerController2D>() != null) {
            
            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            Play2DSound(collectSound, 0.5f); // Play the collection sound
        }

        
    }

    void Play2DSound(AudioClip clip, float volume)
    {
        GameObject tempGO = new GameObject("TempAudio");
        AudioSource aSource = tempGO.AddComponent<AudioSource>();

        aSource.clip = clip;
        aSource.spatialBlend = 0f;
        aSource.Play();
        aSource.volume = volume;

        Destroy(tempGO, clip.length);
    }

}


