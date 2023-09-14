using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements.Experimental;

public class JellyfishCuscenePureGem : MonoBehaviour
{
    private PlayableDirector timeline;
    public GameObject pureGem;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;

    }


    private void OnTimelineStopped(PlayableDirector director)
    {
        pureGem.SetActive(true);
    }
}
