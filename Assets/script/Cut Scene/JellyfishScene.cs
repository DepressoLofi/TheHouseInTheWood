using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class JellyfishScene : MonoBehaviour
{
    public PlayableDirector stage1;
    public PlayableDirector stage2;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson1;
    [SerializeField] private TextAsset inkJson2;

 

    private void Awake()
    {
        stage1.stopped += OnStage1Stopped;
        stage1.Play();
        
    }

    private void OnDestroy()
    {
        stage1.stopped -= OnStage1Stopped; 
    }

    private void OnStage1Stopped(PlayableDirector director)
    {
        if (director == stage1)
        {
            DialManager.Instance.EnterDialogueMode(inkJson1);
        }
    }
}
