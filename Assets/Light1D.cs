using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1D : MonoBehaviour
{
    public GameObject _3DLight;
    public Material _Yellow;
    void Update()
    {
        if ( _3DLight != null)
        {
            if (_3DLight.GetComponent<Renderer>().material.name == "Drag_temp (Instance)")
            {
                GetComponent<Renderer>().material = _Yellow;
            }
        }
    }
}
