using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{
    public float speed = 0.5f; // Adjust the speed of movement as per your preference

    private RectTransform rectTransform;
    private bool isMoving = true;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 scale = rectTransform.localScale;
            scale.x -= speed * Time.deltaTime;
            rectTransform.localScale = scale;

            if (scale.x <= 0f)
            {
                isMoving = false;
                gameObject.SetActive(false);
            }
        }
    }
}
