using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FireKingIntro : MonoBehaviour
{
    private PlayableDirector timeline;

    public FireKing fk;
    public GameObject bossInfo;
    public GameObject Spawners;
    public AudioSource backgroundMusic;
    public AudioSource introSound;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;
        introSound.Play();
    }



    private void OnTimelineStopped(PlayableDirector director)
    {
        fk.StartFight();
        bossInfo.SetActive(true);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        if (introSound != null)
        {
            introSound.Stop();
        }
        if (Spawners != null)
        {
            Spawners.SetActive(true);
        }
    }
}
