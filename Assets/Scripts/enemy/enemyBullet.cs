using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public GameObject effect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "enemy")
        {
            // Physics.IgnoreCollision(collision.gameObject.collider, cocollider);
        }
        else if(collision.gameObject.tag == "Player")
        { 
            collision.gameObject.GetComponent<Player>().TakeDamage(10);
        }
        
        GameObject effects = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(effects, 0.5f);
        Destroy(gameObject);
    }
}
