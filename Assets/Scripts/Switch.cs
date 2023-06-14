using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool _isOn;
    public bool _CorrectState;
    public bool _Correct = false;
    public bool _CanFlip = true;
    public GameObject _LeverManager;
    public GameObject _Wire;
    bool _callCheck = false;


    private void Start()
    {
        SetupConections();
    }

    //rotates the lever and turns on/ off bool switch
    private void OnMouseDown()
    {
        if (_CanFlip)
        {
            if (_isOn)
            {
                _isOn = false;
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (!_isOn)
            {
                _isOn = true;
                transform.localEulerAngles = new Vector3(0, 0, 35);
            }
            _callCheck = true;
        }
    }

    private void Update()
    {
        //checks if the switch is correct
        if (_CanFlip)
        {
            if (_isOn == _CorrectState)
            {
                _Correct = true;
            }
            if (_isOn != _CorrectState)
            {
                _Correct = false;
            }
        }
        //calls to check if the puzzle is solved once
        if (_callCheck)
        {
            _LeverManager.GetComponent<LeverManager>().CheckPuzzle();
            _callCheck = false;
        }

        if (_Correct)
        {
            _Wire.GetComponent<Wires>()._isOn = true;
            _Wire.GetComponent<Wires>().ChangeMaterial();
        }
        else if (!_Correct)
        {
            _Wire.GetComponent<Wires>()._isOn = false;
            _Wire.GetComponent<Wires>().ChangeMaterial();
        }
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _LeverManager = transform.parent.parent.gameObject;
    }


}
