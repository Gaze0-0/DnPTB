using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject _Camera_GameManager;
    public GameObject _Button_Lid;

    private void Start()
    {
        SetupConections();
    }

    //if the key is dragged onto the object then puzzle is solved and lock count -1
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
            _Button_Lid.GetComponent<CaseMovement>()._OpenCase = true;
        }
    }


    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
        if (GameObject.Find("Button case pivot point") != null)
        {
            _Button_Lid = GameObject.Find("Button case pivot point");
        }
    }
}
