using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject _Camera_GameManager;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        SetupConections();
        audioSource.Stop();
    }

    //when button is pressed change the scene by incrementing the current scene by 1;
    private void OnMouseDown()
    {
        if (_Camera_GameManager.GetComponent<GameManager>()._Lock_Count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_Camera_GameManager.GetComponent<GameManager>()._Lock_Count > 0)
        {
            _Camera_GameManager.GetComponent<Camerashake>()._CanShake = true;
            PlayAudioClipAndWait();
        }
    }

    //sets up Connections at the start of the game
    void SetupConections()
    {
        _Camera_GameManager = GameObject.Find("Main Camera");
    }


    private void PlayAudioClipAndWait()
    {
        audioSource.clip = audioClip;
        audioSource.Play();

        StartCoroutine(WaitForAudioClipToEnd());
    }
    private IEnumerator WaitForAudioClipToEnd()
    {
        yield return new WaitForSeconds(0.75f);
        
        
    }

}
