using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalBossBegin : MonoBehaviour
{
    private PlayableDirector timeline;
    private DarkLord dk;
    private DarkLordClone dkc;

    public GameObject bossInfo;
    public AudioSource backgroundMusic;
    public AudioSource introSound;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        dk = FindObjectOfType<DarkLord>();
        dkc = FindObjectOfType<DarkLordClone>();
        timeline.stopped += OnTimelineStopped;
        introSound.Play();
    }



    private void OnTimelineStopped(PlayableDirector director)
    {
        dk.StartFight();
        dkc.StartFight();
        bossInfo.SetActive(true);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        if (introSound != null)
        {
            introSound.Stop();
        }
    }


}
