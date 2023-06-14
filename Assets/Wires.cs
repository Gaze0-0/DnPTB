using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    public bool _isOn = false;
    public Material _IsOff;
    public Material _IsOn;

    public void ChangeMaterial()
    {
        if (_isOn)
        {
            GetComponent<Renderer>().material = _IsOn;
        }
        if (!_isOn)
        {
            GetComponent<Renderer>().material = _IsOff;
        }
    }
}
