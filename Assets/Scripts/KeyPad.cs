using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    public string _Code;
    public string _CorrectCode;
    public bool _IsActive = true;
    public bool _Check = false;
    public GameObject _Camera_GameManager;
    public TextMeshPro _Screen;

    private void Start()
    {
        SetupConections();
    }
    private void Update()
    {
        if (_IsActive)
        {
            _Screen.text = _Code;//prints the code entered onto the screen display
                        
            if (_Check)
            {
                //if the code is equal or longer than the correct code and incorrect then the code is reset to nothing
                if (_Code != _CorrectCode)
                {
                   _Code = "";
                   //make something red or react that its negative
                }
                //if the code is coorect then remove a lock count from the game manager
                else if (_Code == _CorrectCode)
                {
                    _IsActive = false;
                    _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
                }

                _Check = false;
            }
        }
    }


    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
        _Screen = transform.Find("Code Number").GetComponentInChildren<TextMeshPro>();
    }

}
