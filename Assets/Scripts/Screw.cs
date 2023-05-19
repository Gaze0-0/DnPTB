using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public float rotationSpeed = 10f;
    float verticalSpeed = .005f;
    bool _IsRotating = false;
    float _RotatingTimer = 2.5f;
    bool _IsUnscrewed = false;
    public GameObject _ScrewDriver;
    public GameObject _ScrewCase;


    private void Update()
    {
        //rotates till the seconds needed to rotate are done and 
        if (_RotatingTimer > 0)
        {
            if (_IsRotating)
            {
                // Rotate counterclockwise
                RotateObjectCounterclockwise();
                _RotatingTimer -= Time.deltaTime;
                transform.Translate(0, verticalSpeed, 0);
            }
        }
        else
        {
            _IsUnscrewed = true;
        }
        //when unswrew is done, destroy this screw
        if (_IsUnscrewed)
        {
            _ScrewCase.GetComponent<BatteryCase>()._Screws--;
            Destroy(this.gameObject);
        }
    }

    //starts rotating
    private void OnMouseDown()
    {
        _IsRotating = true;
        _ScrewDriver.SetActive(true);

    }

    //stops rotating
    private void OnMouseUp()
    {
        _IsRotating = false;
        _ScrewDriver.SetActive(false);
    }

    //rotates this counter clockwise
    void RotateObjectCounterclockwise()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
