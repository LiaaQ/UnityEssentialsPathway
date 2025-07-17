using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    public AudioClip success; // Optional: Audio clip to play when all collectibles are collected
    public string collectibleName = "Collectibles"; // Name of the collectible type to look for

    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Optionally, check and count objects of type Collectible2D
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        if (totalCollectibles == 0)
        {
            if (collectibleText.text != "All " + collectibleName.ToLower() + " collected!")
            {
                collectibleText.text = "All " + collectibleName.ToLower() + " collected!";
                if (success != null)
                {
                    Play2DSound(success, 0.5f); // Play success sound if available
                }
            }
            return; // stop here
        }

        // Otherwise: show remaining count
        collectibleText.text = collectibleName + $" remaining: {totalCollectibles}";
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