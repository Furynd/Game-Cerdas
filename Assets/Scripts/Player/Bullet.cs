using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    public int damage;

    void Start(){
        StaticVar stat = GameObject.FindGameObjectWithTag("Statics").GetComponent<StaticVar>();
        damage = stat.damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag != "Player")
        { 
            GameObject effects = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effects, 0.5f);
            Destroy(gameObject);
        }
    }
}
