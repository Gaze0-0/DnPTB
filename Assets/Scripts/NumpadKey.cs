using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NumpadKey : MonoBehaviour
{
    public string _Key;
    public GameObject _Keypad;

    private void Start()
    {
        SetupConections();
    }

    //tells the parent keypad to add this keys value to the code that is being entered
    private void OnMouseDown()
    {
        _Keypad.GetComponent<KeyPad>()._Code += _Key;
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Keypad = transform.parent.gameObject;
    }
}
