using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    void Start()
    {
        // Get the Renderer component of the cube
        Renderer cubeRenderer = GetComponent<Renderer>();

        // Calculate the position of the cube's center
        Vector3 cubeCenter = transform.position;

        // Get the size of the cube
        Vector3 cubeSize = transform.localScale;

        // Calculate the x-coordinate at which the color should change
        float colorChangeX = cubeCenter.x + cubeSize.x / 4f;

        // Get the position of the cube
        Vector3 cubePosition = transform.position;

        // Check if the cube's x-coordinate is greater than the color change x-coordinate
        if (cubePosition.x > colorChangeX)
        {
            cubeRenderer.material.color = Color.red;
        }
        else
        {
            cubeRenderer.material.color = Color.green;
        }
    }
}


