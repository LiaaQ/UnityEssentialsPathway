using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    public AudioClip bounceSound;
    public float maxImpactVelocity = 10f;  // impact velocity that maps to full volume

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Wall"))
        {
            // Get the impact strength (relative velocity of collision)
            float impactStrength = collision.relativeVelocity.magnitude;

            // Map impactStrength to volume (0.0 - 1.0)
            float volume = Mathf.Clamp01(impactStrength / maxImpactVelocity);

            // Play the sound at the scaled volume
            AudioSource.PlayClipAtPoint(bounceSound, transform.position, volume);
        }
    }
}
