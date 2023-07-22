using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;

    public void Start()
    {
        
        GameObject emilyHitBoxObject = GameObject.Find("Emily/HitBox");

       
        if (emilyHitBoxObject != null)
        {
            
            CircleCollider2D emilyHitBox = emilyHitBoxObject.GetComponent<CircleCollider2D>();

            
            if (emilyHitBox != null)
            {
                
                Physics2D.IgnoreCollision(emilyHitBox, GetComponent<Collider2D>());
            }
            else
            {
                Debug.LogError("CircleCollider2D component not found on 'Emily/HitBox'.");
            }
        }
        else
        {
            Debug.LogError("GameObject 'Emily/HitBox' not found.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Triggered scene transition");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
