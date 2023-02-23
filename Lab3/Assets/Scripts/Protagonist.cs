using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour

{

    private Rigidbody2D body;
    public float horizontal;
    public float vertical;

    private float moveLimiter = 0.7f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem particleSystem;
    private TrailRenderer trailRenderer;

    public float runSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("horizontal", horizontal);
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
            particleSystem.Stop();
            trailRenderer.enabled = true;
        } if (horizontal > 0) {
            spriteRenderer.flipX = false;
            trailRenderer.enabled = false;
        } if (vertical != 0) {
            particleSystem.Play();
        } if (vertical == 0) {
            particleSystem.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            print("Space!");
            body.AddForce(new Vector2(0, runSpeed * 100));
        }

    }

    void FixedUpdate() {
        if (horizontal != 0 && vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
