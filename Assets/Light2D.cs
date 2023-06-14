using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2D : MonoBehaviour
{
    public GameObject _3DLight;
    public GameObject _2DKeypad;
    public GameObject _isOff;
    public GameObject _isOn;

    void Update()
    {
        if (_3DLight != null)
        {
            if (_3DLight.GetComponent<Renderer>().material.name == "Drag_temp (Instance)")
            {
                _isOff.gameObject.SetActive(false);
                _isOn.gameObject.SetActive(true);
            }             
        }
        if (_2DKeypad != null)
        {
            if (_2DKeypad.GetComponent<KeyPad>()._IsActive == false)
            {
                _isOff.gameObject.SetActive(false);
                _isOn.gameObject.SetActive(true);
            }            
        }

    }

}
