using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _Timer;
    public float _Timer_Countdown;
    public int _Lock_Count;
    public bool _HoldingObject = false;
    public float _barCountDown;
    public GameObject _Bar;
    private void Start()
    {
        _Timer_Countdown = 30.25f;
        SetupConections();
    }

    private void Update()
    {
        //converts the float to an string and rounds it to whole unmbers then displays it in the UI
        //_Timer.text = Mathf.RoundToInt(_Timer_Countdown).ToString();

        Countdown();
        Locks();
    }


    //if the countdown number is above 0 then it will count down to 0 then stop 
    void Countdown()
    {     
        if (_Timer_Countdown > 0)
        {
            _Timer_Countdown -= Time.deltaTime;
            _barCountDown = Mathf.Lerp(0,1, _Timer_Countdown/30.25f);
            _Bar.GetComponent<RectTransform>().localScale = new Vector3(_barCountDown,1,1);

        }
        if (_Timer_Countdown < 0)
        {
            Application.Quit();
        }
    }

    //if all the locks are solved then the button can be pressed
    void Locks()
    {
        if (_Lock_Count <= 0)
        {

        }
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _Bar = GameObject.Find("Bar Green");
    }
}
