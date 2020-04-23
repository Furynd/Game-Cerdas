using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint,firePointb,firePointc,firePointd;
    public GameObject bulletPrefab;
    public float bulletforce = 20f;
    public Animator animator;
    public float lookDirx;
    public float lookDiry;

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
            Shoot();    
        }
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attack");
            Shoot();
        }
    }

    void Shoot()
    {
        if (lookDirx*lookDirx < lookDiry*lookDiry)
        {
            // if(lookDiry > 0)
        }
        else
        {

        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);

    }
}
