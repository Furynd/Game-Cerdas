using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Rigidbody2D player;
    public int count = 0;

    Vector2 movement;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject, 0.2f);
        }
        if(count%2 == 0){
            movement.x = 0;
            movement.y = 0;
        }
        // else if(count%10 <= 5){
        //     movement.x = Random.Range(-1, 2);
        //     movement.y = Random.Range(-1, 2);
        // }
        else{
            float temp = player.position.x - rb.position.x;
            if(temp > 0) movement.x = 1;
            else movement.x = -1;
            temp = player.position.y - rb.position.y;
            if(temp > 0) movement.y = 1;
            else movement.y = -1;
        }
        count = (count+1) % 10;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "playerbullet"){
            TakeDamage(50);
            // Destroy(gameObject, 0.2f);
        }
    }
}
