using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFeedback : MonoBehaviour
{
    public Material _LightOn;

    public void ChangeColour()
    {
        GetComponent<Renderer>().material = _LightOn;
    }
    //sets up Connections at the start of the game
    void SetupConections()
    {

    }
}
