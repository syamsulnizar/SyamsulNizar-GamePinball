using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Animator animator;
    public Collider ball;
    public Color colorHit;
    public Color colorIdle;

    public float multiplier;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<Renderer>().material.color = colorIdle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == ball)
        {
            animator.SetTrigger("hit");
            GetComponent<Renderer>().material.color = colorHit;

            Rigidbody rigidBall = ball.GetComponent<Rigidbody>();
            rigidBall.velocity *= multiplier;
        }
    }
    public void Idle()
    {
        animator.SetTrigger("idle");
        GetComponent<Renderer>().material.color = colorIdle;
    }
}
