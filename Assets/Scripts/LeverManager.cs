using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public List<GameObject> _Levers;
    public GameObject _Camera_GameManager;

    int _CorrectCount;

    //this is a function called after each time a leverl is switched
    public void CheckPuzzle()
    {
        for (int i = 0; i < _Levers.Count; i++)
        {
            if (_Levers[i].GetComponent<Switch>()._Correct == true)
            {
                _CorrectCount++;
            }
            else
            {
                _CorrectCount = 0;
                return;
            }
        }
        if (_CorrectCount == _Levers.Count)
        {
            
            for (int i = 0; i < _Levers.Count; i++)
            {
                _Levers[i].GetComponent<Switch>()._CanFlip = false;
            }
            _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
        }
        if ( _CorrectCount != _Levers.Count)
        {
            _CorrectCount = 0;
        }
    }
    
}
