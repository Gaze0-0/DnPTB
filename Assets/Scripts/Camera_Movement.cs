using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this for when the camera is in orthographic perspective
public class Camera_Movement : MonoBehaviour
{
    float startSzie;
    public float endSzie;
    void Start()
    {
        startSzie = GetComponent<Camera>().orthographicSize;
        
    }

    void Update()
    {
        CameraMove();
    }

    //scales back the view pespective when the camera is in orthographic view
    void CameraMove()
    {
        if (startSzie < endSzie)
        {
            GetComponent<Camera>().orthographicSize = startSzie;
            startSzie += 0.1f;
        }
    }
}
