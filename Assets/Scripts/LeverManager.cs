using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public List<GameObject> _Levers;
    public GameObject _Camera_GameManager;
    public GameObject _Light;

    int _CorrectCount;


    private void Start()
    {
        SetupConections();
    }

    //this is a function called after each time a leverl is switched
    public void CheckPuzzle()
    {
        //goes through each lever to check if the correct state is switched on and if it is add 1 to the correct count integer
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
        //if the number of correct answers match the amount of levers in the puzzle then the puzzle is solved
        if (_CorrectCount == _Levers.Count)
        {
            
            for (int i = 0; i < _Levers.Count; i++)
            {
                _Levers[i].GetComponent<Switch>()._CanFlip = false;
            }
            _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
            _Light.GetComponent<LightFeedback>().ChangeColour();
        }
        if ( _CorrectCount != _Levers.Count)
        {
            _CorrectCount = 0;
        }
    }


    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
        _Light = transform.parent.gameObject; 


        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            Transform grandchildTransform = childTransform.GetChild(0);
            _Levers.Add(grandchildTransform.gameObject);
            
        }
    }


}
