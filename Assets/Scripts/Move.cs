using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private Collider2D col;
    public int Speed = 1000;
    private GameObject Picking;
    private Vector2 stop;
    private Animator ani;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        stop.Set(0, 0);
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.E))
        {
            // OnCollisionEnter(col, Picking);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * Speed * Time.fixedDeltaTime);
        if (movement == stop)
        {
            rb.velocity = stop;
            ani.SetBool("idle", true);
            ani.SetBool("walking", false);
            ani.Play("shooting", -1, 0f);

        }
        else
        {
            ani.SetBool("walking", true);
            ani.SetBool("idle", false);
        }

    }
}
