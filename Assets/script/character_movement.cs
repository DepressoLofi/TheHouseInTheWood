using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    private Vector2 movement;
    private Animator animator;
    private bool canMove = true;
    public float initialHorizontal;
    public float initialVertical;

    public MouseAim mouseAim; // Reference to the MouseAim script
    public Weapon weapon; // Reference to the Weapon script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("horizontal", initialHorizontal);
        animator.SetFloat("vertical", initialVertical);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to avoid diagonal movement being faster
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Check for firing input
        if (Input.GetMouseButtonDown(0))
        {
            // Get the fire direction from MouseAim script and pass it to the Fire method in Weapon script
            Vector2 fireDirection = mouseAim.GetFireDirection();
            weapon.Fire(fireDirection);
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("momentum", movement.sqrMagnitude);
        if (movement != Vector2.zero && canMove)
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);

            moveCharacter();
        }
    }

    void moveCharacter()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
