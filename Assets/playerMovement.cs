using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Rigidbody2D firePoint;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 lookDir;


    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - rb.position;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("lookx", lookDir.x);
        animator.SetFloat("looky", lookDir.y);

        float angle = Mathf.Atan2(-lookDir.x, lookDir.y) * Mathf.Rad2Deg;
        firePoint.rotation = angle;
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement*moveSpeed* Time.fixedDeltaTime);
        firePoint.MovePosition(firePoint.position + movement*moveSpeed* Time.fixedDeltaTime);
    }
}
