using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject _Camera_GameManager;

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
        }
    }


    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
    }
}
