using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLock : MonoBehaviour
{
    public GameObject Battery;

    //when a battery colides with the trigger the battery will be destroyed and the battery which is disabled inside the prefab will be enabled.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            Battery.SetActive(true);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            //this tells the case that a battery has been succcessfully installed
            this.GetComponentInParent<BatteryCase>().Batteries++;
        }
        
    }
    //sets up Connections at the start of the game
    void SetupConections()
    {
        
    }
}
