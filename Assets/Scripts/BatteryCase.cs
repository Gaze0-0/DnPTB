using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCase : MonoBehaviour
{
    public GameObject _Lid;
    public GameObject _Trigger1;
    public GameObject _Trigger2;
    public int _Screws;
    public int Batteries = 0;

    public GameObject Wire;

    public GameObject _Camera_GameManager; //referance to game Manager in the camera


    private void Start()
    {
        SetupConections();
    }

    private void Update()
    {
        Screws();
        BatteriesCheck();
        
    }

    //checks if all screws are removed to activate the triggers for part 2 of the puzzle
    void Screws()
    {
        if (_Screws == 0)
        {
            _Trigger1.SetActive(true);
            _Trigger2.SetActive(true);
            _Screws--;
            Destroy(_Lid.gameObject);
        }
    }

    //checks if all batteries are installed and if so tells the game manager to remove a lock from its count
    void BatteriesCheck()
    {
        if (Batteries == 2)
        {
            _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
            Batteries++;
            Wire.GetComponent<Wires>()._isOn = true;
            Wire.GetComponent<Wires>().ChangeMaterial();
        }
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
    }
}
