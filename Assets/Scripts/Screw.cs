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
    public bool _Is2D = false;
    private void Start()
    {
        SetupConections();
    }
    private void Update()
    {
        //rotates till the seconds needed to rotate are done and 
        if (_RotatingTimer > 0)
        {
            if (_IsRotating)
            {
                if (_Is2D == false)
                {
                    // Rotate counterclockwise
                    RotateObjectCounterclockwise();
                    _RotatingTimer -= Time.deltaTime;
                    transform.Translate(0, verticalSpeed, 0);
                }
                if (_Is2D)
                {
                    _RotatingTimer -= Time.deltaTime;
                    RotateObjectCounterclockwise();
                }
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
        if (_Is2D == false)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (_Is2D)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _ScrewDriver = transform.GetChild(0).gameObject;
        _ScrewCase = transform.parent.gameObject;
    }

}
