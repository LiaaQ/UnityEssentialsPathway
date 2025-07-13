using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Time in seconds for a full day to pass.")]
    public float dayDuration = 60f; // Default: 1 minute per full day

    private float rotationSpeed;

    void Start()
    {
        // 360 degrees over the duration of a full day
        rotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        // Rotate around the X axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
