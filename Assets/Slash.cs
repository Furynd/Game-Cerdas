using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    // public RigidBody rb;
    // Start is called before the first frame update
    void Start()
    {
        // rb.MoveRotation(rb.ro)
        Destroy(gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Sliced");
            // TakeDamage(50);
            // Destroy(gameObject, 0.2f);
        }
    }
}
