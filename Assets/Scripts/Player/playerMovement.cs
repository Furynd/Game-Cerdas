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
    public firePos pos;
    GameObject enemy;

    Vector2 movement;
    Vector2 mousePos;
    public Vector2 lookDir;
    float tempx;
    float tempy;
    float angle;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        enemy = FindClosestEnemy();
        if( enemy != null){
            tempx = enemy.transform.position.x - rb.position.x;
            tempy = enemy.transform.position.y - rb.position.y;
            angle = Mathf.Atan2(-tempx, tempy) * Mathf.Rad2Deg;
        }
        else {
            tempx = 0;
            tempy = 0;
            angle = 0;
        }

        firePoint.rotation = angle;
        lookDir.x = tempx;
        lookDir.y = tempy;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("lookx", tempx);
        animator.SetFloat("looky", tempy);
        // firePoint.rotation = angle;
        firePoint.MoveRotation(angle);
        //movement
        rb.MovePosition(rb.position + movement*moveSpeed* Time.fixedDeltaTime);
        firePoint.MovePosition(firePoint.position + movement*moveSpeed* Time.fixedDeltaTime);
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
