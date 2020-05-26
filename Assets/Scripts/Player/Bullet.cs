using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            // Physics.IgnoreCollision(collision.gameObject.collider, cocollider);
        }
        else
        { 
            GameObject effects = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effects, 0.5f);
            Destroy(gameObject);
        }
    }
}
