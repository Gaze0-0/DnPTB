using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject _Camera_GameManager;
    //when button is pressed change the scene by incrementing the current scene by 1;
    private void OnMouseDown()
    {
        if (_Camera_GameManager.GetComponent<GameManager>()._Lock_Count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
