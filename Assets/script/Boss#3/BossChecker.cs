using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossChecker : MonoBehaviour
{
    private bool played = false;

    public GameObject bossInfo;

    private GameObject dk;
    private DarkLord dks;
    private Camera cam;

    private float cameraSpeed = 2f;
    private Vector3 targetCameraPosition;

    public PlayableDirector cutscene;

    private BackgroundMusicManager bgm;
    public AudioSource endingSong;


    private void Start()
    {
        dk = GameObject.Find("Dark Souls");
        dks = FindObjectOfType<DarkLord>();
        bgm = FindObjectOfType<BackgroundMusicManager>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (dks.die)
        {
            if (!played)
            {
                played = true;
                BossDied();
            }

        }

        
    }

    private void BossDied()
    {
        
        bossInfo.SetActive(false);
        
        bgm.FadeOutMusic();
        if (endingSong != null)
        {
            endingSong.Play();
        }
        cutscene.Play();
        targetCameraPosition = new Vector3(dk.transform.position.x, dk.transform.position.y, -10);
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        while (Vector3.Distance(cam.transform.position, targetCameraPosition) > 0.01f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetCameraPosition, Time.deltaTime * cameraSpeed);
            yield return null;
        }
    }


}
