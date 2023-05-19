using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Out : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of the fade in seconds

    private Material material; // Reference to the material
    private float currentAlpha = 1f; // Current alpha value

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    private void Update()
    {
        // Reduce alpha value based on time
        currentAlpha -= Time.deltaTime / fadeDuration;

        // Clamp alpha value between 0 and 1
        currentAlpha = Mathf.Clamp01(currentAlpha);

        // Update material's alpha value
        Color color = material.color;
        color.a = currentAlpha;
        material.color = color;

        // Check if transparency has reached 0
        if (currentAlpha <= 0f)
        {
            // Disable or destroy the object if desired
            //gameObject.SetActive(false); // Disable the object
            // or
             Destroy(gameObject); // Destroy the object
        }
    }
}
