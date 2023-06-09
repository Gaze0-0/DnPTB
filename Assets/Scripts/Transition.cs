using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Transition : MonoBehaviour
{
    public Volume volume;
    private Exposure exposure;
    float _CorrectExposure = 10.75f;
    public bool _is2D = false;
    public GameObject _blackoutScren;

    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        //volume.profile.TryGet(out exposure);
        audioSource = GetComponent<AudioSource>();
        // if (transform.GetChild(0).gameObject != null)
        //{
        //  _blackoutScren = transform.GetChild(0).gameObject;
        // }
        PlayAudioClipAndWait();
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
        Destroy(this.gameObject);
        /*while (audioSource.isPlaying)
        {
            if (_is2D == false)
            {
                //this.exposure.fixedExposure.value = _CorrectExposure;
            }
            if (_is2D)
            {
                // this._blackoutScren.SetActive(false);
               
            }
            yield return null;
        }*/
    }
}
