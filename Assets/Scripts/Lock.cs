using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject _Camera_GameManager;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            _Camera_GameManager.GetComponent<GameManager>()._Lock_Count--;
        }
    }
}
