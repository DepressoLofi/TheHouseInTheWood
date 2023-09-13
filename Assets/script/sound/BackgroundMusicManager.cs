using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private float fadeDuration = 1f;
    private bool fadingOut = false;
    private float initialVolume;
    private float timer = 0f;
    private GameObject[] musicObj;


   
    void Awake()
    {
        musicObj = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }


        bgmAudioSource = GetComponent<AudioSource>();

        initialVolume = bgmAudioSource.volume;

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
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

        Destroy(this.gameObject);
        fadingOut = false;
        bgmAudioSource.volume = initialVolume;
    }

    public void ContinueMusic()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
