using UnityEngine;

public class BossFireBall : MonoBehaviour, IDamageable
{

    private Player player;
    [SerializeField] private int damageAmount;
    public GameObject effect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();
    }

    void Hit()
    {
        GameObject smokeEffect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(smokeEffect, 0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emily"))
        {
            player.TakeDamage(damageAmount);
            Hit();
        }
    }

    public void Damage(int damage, Transform p )
    {   
        Hit();
    }
}
