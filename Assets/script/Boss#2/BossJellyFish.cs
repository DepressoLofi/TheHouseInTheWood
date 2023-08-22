using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJellyFish : MonoBehaviour
{

    [SerializeField] float speed = 0.5f;
    private float deadzone = 40f;

    //colliding with Emily
    private bool canDealDamage = true;
    private float cooldownDuration = 0.5f;
    private float lastDamageTime = 0f;

    void Update()
    {
        transform.position = transform.position + (Vector3.right * speed) * Time.deltaTime;

        if (transform.position.x > deadzone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDealDamage && Time.time - lastDamageTime >= cooldownDuration)
        {
            if (other.gameObject.CompareTag("Emily"))
            {
                Player emily = other.gameObject.GetComponent<Player>();
                emily.TakeDamage(5);

                lastDamageTime = Time.time;
                canDealDamage = false;
                StartCoroutine(ResetCooldown());
            }
        }
    }

    private System.Collections.IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canDealDamage = true;
    }
}
