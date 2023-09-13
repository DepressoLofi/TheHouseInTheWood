using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public int totalFireSkull;
    private FireKing fk;
    private GameObject FireKing;

    public PlayableDirector cutscene;
    private Camera cam;
    private bool played = false;

    private float cameraSpeed = 2f; 
    private Vector3 targetCameraPosition;

    private character_movement playerMovement;

    public AudioSource bg;
    private BackgroundMusicManager bgm;


    public GameObject bossInfo;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        fk = FindObjectOfType<FireKing>();
        FireKing = GameObject.Find("FireKing"); 
        cam = Camera.main;
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        bgm = FindObjectOfType<BackgroundMusicManager>();

    }

    private void CountFireSkull()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalFireSkull = enemies.Length;
    }

    private void Update()
    {
        CountFireSkull();
        if (fk.die)
        {
            FireSkull fsk = FindObjectOfType<FireSkull>();
            if (fsk != null)
            {
                fsk.Explode();
            }
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
        playerMovement.SetCanMove(false);
        bgm.FadeOutMusic();
        if (bg != null)
        {
            bg.Play();
        }
        cutscene.Play();
        targetCameraPosition = new Vector3(FireKing.transform.position.x, FireKing.transform.position.y, -10);
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
