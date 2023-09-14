using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SeaKrakenIntro : MonoBehaviour
{
    private PlayableDirector timeline;
    private SeaKraken sk;

    public GameObject bossInfo;
    public GameObject spawners;
    public AudioSource backgroundMusic;
    public AudioSource introSound;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        sk = FindObjectOfType<SeaKraken>();
        timeline.stopped += OnTimelineStopped;
        introSound.Play();
    }



    private void OnTimelineStopped(PlayableDirector director)
    {
        sk.StartTheBattle();
        
        bossInfo.SetActive(true);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        if (introSound != null)
        {
            introSound.Stop();
        }
        if (spawners != null)
        {
            spawners.SetActive(true);
        }
    }
}
