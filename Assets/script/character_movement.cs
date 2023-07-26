using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    Vector2 movement;
    private Animator animator;
    private bool canMove = true;
    private bool transitioning = false;
    public float initialHorizontal;
    public float initialVertical;

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
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        } else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("momentum", movement.sqrMagnitude);
        if (movement != Vector2.zero  && !transitioning)
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);

            movecharacter();
        }
    }

    void movecharacter()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }
    public void SetTransition(bool trans)
    {
        transitioning = trans;
    }

}