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
        if (_IsUnscrewed)
        {
            _ScrewCase.GetComponent<BatteryCase>()._Screws--;
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        _IsRotating = true;
        _ScrewDriver.SetActive(true);

    }

    private void OnMouseUp()
    {
        _IsRotating = false;
        _ScrewDriver.SetActive(false);
    }

    void RotateObjectCounterclockwise()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
