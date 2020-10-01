using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementController : MonoBehaviour
{
    [Range(1, 10)]
    public float velocity = 1;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * velocity;
        animator.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x < 0)
            spriteRenderer.flipX = true;
        else if(rb.velocity.x > 0)
            spriteRenderer.flipX = false;
    }
}
