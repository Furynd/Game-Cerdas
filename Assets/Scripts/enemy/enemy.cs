using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Rigidbody2D player;
    private GameObject statics;
    public Animator animator;
    public int count = 0;
    private bool active = true;
    public bool back = false;

    Vector2 movement;
    Vector2 startpos;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        statics = GameObject.FindGameObjectWithTag("Statics");
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        startpos.x = transform.position.x;
        startpos.y = transform.position.y;
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
            statics.GetComponent<StaticVar>().addScore(1);
            Destroy(gameObject);
        }
        if(count%2 == 0){
            movement.x = 0;
            movement.y = 0;
        }
        // else if(count%10 <= 5){
        //     movement.x = Random.Range(-1, 2);
        //     movement.y = Random.Range(-1, 2);
        // }
        else if(active){
            float temp = player.position.x - rb.position.x;
            if(temp > 0) movement.x = 0.8f;
            else movement.x = -0.8f;
            temp = player.position.y - rb.position.y;
            if(temp > 0) movement.y = 0.8f;
            else movement.y = -0.8f;
        }
        else if(back){
            float dx,dy;
            float temp = startpos.x - rb.position.x;
            dx = temp;
            if(temp > 0) movement.x = 0.8f;
            else movement.x = -0.8f;
            temp = startpos.y - rb.position.y;
            dy = temp;
            if(temp > 0) movement.y = 0.8f;
            else movement.y = -0.8f;
            if(dx< 1 && dy < 1) back = false;
        }
        count = (count+1) % 10;

    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        //// Animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "playerbullet"){
            TakeDamage(50);
            // Destroy(gameObject, 0.2f);
        }
    }

    public void setActive(bool set){
        active = set;
        Debug.Log("Activated");
        if(set == false){
            back = true;
        }
        else back = false;
    }

    // void kill(){
    //     statics.GetComponent<StaticVar>().score++;
    // }
}
