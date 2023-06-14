using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    float _Red = 255;
    float _Green = 255;
    float _Blue = 255;
    float timer;
    float duration = 500;

    void Start()
    {
        _Red = 500;
        _Green = 500;
        _Blue = 500;
       
    }


    void Update()
    {
        GetComponent<UnityEngine.UI.Image>().color = new Color(_Red, _Green, _Blue);
        timer += Time.deltaTime;
        _Red = Mathf.Lerp(_Red, 0, timer / duration);
        _Green = Mathf.Lerp(_Green, 0, timer / duration);
        _Blue = Mathf.Lerp(_Blue, 0, timer / duration);
        if (timer > 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 16);
        }
    }
}
