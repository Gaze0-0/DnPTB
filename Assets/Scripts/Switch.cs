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
    bool _callCheck = false;

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
    }
}
