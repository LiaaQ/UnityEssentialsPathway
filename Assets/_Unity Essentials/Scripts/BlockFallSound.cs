using UnityEngine;

public class BlockFallSound : MonoBehaviour
{
    public AudioClip fallSound;
    public float minImpactVelocity = 0.1f;    // Minimum velocity to play sound
    public float maxImpactVelocity = 10f;     // Velocity that maps to max volume

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Measure the impact velocity (relative to the collision)
        float impactStrength = collision.relativeVelocity.magnitude;

        // Only play sound if above minimum impact threshold
        if (impactStrength >= minImpactVelocity)
        {
            // Map impact strength to 0–1 volume
            float volume = Mathf.Clamp01(impactStrength / maxImpactVelocity);

            AudioSource.PlayClipAtPoint(fallSound, transform.position, volume * 0.6f);
        }
    }
}
