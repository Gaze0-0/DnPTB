using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadKey : MonoBehaviour
{
    public string _Key;
    public GameObject _Keypad;

    //tells the parent keypad to add this keys value to the code that is being entered
    private void OnMouseDown()
    {
        _Keypad.GetComponent<KeyPad>()._Code += _Key;
    }
}
