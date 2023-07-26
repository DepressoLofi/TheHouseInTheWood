using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private float fadeDuration = 1f;
    private bool fadingOut = false;
    private float initialVolume;
    private float timer = 0f;

   
    void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();

        initialVolume = bgmAudioSource.volume;

    }

    public void FadeOutMusic()
    {
        if (!fadingOut)
        {
            fadingOut = true;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float startTime = Time.time;
        float startVolume = bgmAudioSource.volume;

        while (Time.time < startTime + fadeDuration)
        {
            timer = (Time.time - startTime) / fadeDuration;
            bgmAudioSource.volume = Mathf.Lerp(startVolume, 0.0f, timer);
            yield return null;
        }

        bgmAudioSource.Stop();
        bgmAudioSource.volume = initialVolume;
        fadingOut = false;
    }
}
