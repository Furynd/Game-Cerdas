using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint,firePointb,firePointc,firePointd;
    public GameObject bulletPrefab;
    public GameObject slashPrefab;
    public float bulletforce = 20f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
            Invoke("Melee",0.3f);    
        }
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attack");
            Invoke("Shoot",0.3f);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);

    }
    void Melee()
    {
        Vector2 lookDir = gameObject.GetComponent<playerMovement>().lookDir;
        Vector2 newPos = transform.position;
        if(lookDir.x * lookDir.x > lookDir.y * lookDir.y){
            if(lookDir.x > 0){
                newPos.x = firePoint.position.x + 1;
                newPos.y = firePoint.position.y;
            }
            else if(lookDir.x < 0){
                newPos.x = firePoint.position.x - 1;
                newPos.y = firePoint.position.y;
            }
        }
        else if(lookDir.x * lookDir.x < lookDir.y * lookDir.y){
            if(lookDir.y > 0){
                newPos.x = firePoint.position.x;
                newPos.y = firePoint.position.y + 1;
            }
            else if(lookDir.y < 0){
                newPos.x = firePoint.position.x;
                newPos.y = firePoint.position.y-1;
            }
        }

        GameObject bullet = Instantiate(bulletPrefab, newPos, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);
    }
}
