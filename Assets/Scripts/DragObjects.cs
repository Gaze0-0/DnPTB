using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Rendering;

public class DragObjects : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialClickPosition;
    private Vector3 initialObjectPosition;
    private float zDistanceToCamera;
    private Collider objectCollider;
    public GameObject _Camera_GameManager;


    private void Start()
    {
        isDragging = false;
        zDistanceToCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        objectCollider = GetComponent<Collider>();
        SetupConections();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            if (_Camera_GameManager.GetComponent<GameManager>()._HoldingObject == false)
            {
                if (!isDragging)
                {
                    isDragging = true;
                    _Camera_GameManager.GetComponent<GameManager>()._HoldingObject = true;
                    initialClickPosition = GetMouseWorldPosition();
                    initialObjectPosition = transform.position;
                    objectCollider.enabled = false; // Disable the collider while dragging

                }
            }
            
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Get the position of the hit point in world space
                Vector3 currentMousePosition = hit.point;

                // Calculate the new position of the dragged object
                transform.position = new Vector3(currentMousePosition.x, currentMousePosition.y, currentMousePosition.z);

                // Visualize the raycast line in the editor
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }

            if (Input.GetMouseButtonDown(1))
            {
                isDragging = false;
                objectCollider.enabled = true; // Enable the collider after dragging
                _Camera_GameManager.GetComponent<GameManager>()._HoldingObject = false;
            }
        }


    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Set the z-coordinate to the distance from the camera to the object
        mousePosition.z = zDistanceToCamera;

        // Convert the screen position to world space
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
    }

}
