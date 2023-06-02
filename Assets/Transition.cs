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

    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        volume.profile.TryGet(out exposure);
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayAudioClipAndWait();
        exposure.fixedExposure.value = _CorrectExposure;
    }

    private void PlayAudioClipAndWait()
    {
        audioSource.clip = audioClip;
        audioSource.Play();

        StartCoroutine(WaitForAudioClipToEnd());
    }
    private IEnumerator WaitForAudioClipToEnd()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
