using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject slashPrefab;
    public float bulletforce = 20f;
    public Animator animator;
    private float attackRate = 1.0f;
    private float nextAttack = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttack){
            if(Input.GetKeyDown(KeyCode.Z))
            {
                nextAttack = Time.time + attackRate;
                animator.SetTrigger("attack");
                Invoke("Melee",0.0f);    
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                if(gameObject.GetComponent<Player>().UseMana(5)){
                    nextAttack = Time.time + attackRate;
                    animator.SetTrigger("attack");
                    Invoke("Shoot",0.0f);
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);
    }
    void Melee()
    {
        Vector2 lookDir = gameObject.GetComponent<playerMovement>().lookDir;
        
        Vector2 newPos = transform.position;
        Quaternion qn = new Quaternion(0,0,0,1);
        if(lookDir.x * lookDir.x > lookDir.y * lookDir.y){
            if(lookDir.x > 0){
                qn = new Quaternion(0,0,-1,1);
                newPos.x = transform.position.x + 1;
                newPos.y = transform.position.y;
            }
            else if(lookDir.x < 0){
                qn = new Quaternion(0,0,1,1);
                newPos.x = transform.position.x - 1;
                newPos.y = transform.position.y;
            }
        }
        else if(lookDir.x * lookDir.x < lookDir.y * lookDir.y){
            if(lookDir.y > 0){
                qn = new Quaternion(0,0,0,1);
                newPos.x = transform.position.x;
                newPos.y = transform.position.y + 1;
            }
            else if(lookDir.y < 0){
                qn = new Quaternion(0,0,1,0);
                newPos.x = transform.position.x;
                newPos.y = transform.position.y-1.5f;
            }
        }
        // Vector2 sRotation = firePoint.rotation;
        // sRotation.z -=90f;

        GameObject bullet = Instantiate(slashPrefab, newPos, qn);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
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
