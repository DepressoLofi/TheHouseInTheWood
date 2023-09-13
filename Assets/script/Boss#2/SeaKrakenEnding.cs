using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SeaKrakenEnding : MonoBehaviour
{
    private SeaKraken sk;
    private BackgroundMusicManager bgm;
    public AudioSource bg;
    public GameObject bossInfo;

    private GameObject seaKraken;
    private float cameraSpeed = 2f;
    private Vector3 targetCameraPosition;

    public PlayableDirector cutscene;
    private Camera cam;
    private character_movement playerMovement;


    private bool played = false;
    void Start()
    {
        sk = FindAnyObjectByType<SeaKraken>();
        bgm = FindObjectOfType<BackgroundMusicManager>();
        seaKraken = GameObject.Find("Sea Kraken");
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        cam = Camera.main;
    }


    void Update()
    {
        if(sk.die && !played)
        {
            played = true;
            BossDie();
        }
    }

    private void BossDie()
    {
        playerMovement.SetCanMove(false);
        bossInfo.SetActive(false);
        bgm.FadeOutMusic();
        if (bg != null)
        {
            bg.Play();
        }

        cutscene.Play();
        targetCameraPosition = new Vector3(seaKraken.transform.position.x, seaKraken.transform.position.y, -10);
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
