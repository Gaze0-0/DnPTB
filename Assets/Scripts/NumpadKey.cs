using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadKey : MonoBehaviour
{
    public string _Key;
    public GameObject _Keypad;

    private void OnMouseDown()
    {
        _Keypad.GetComponent<KeyPad>()._Code += _Key;
    }
}
