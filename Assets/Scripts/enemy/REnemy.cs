using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REnemy : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Rigidbody2D firePoint;
    public Transform firePointTransform;
    public float bulletforce = 10f;

    private Rigidbody2D player;
    private GameObject statics;
    public Animator animator;
    public int count = 0;
    private bool active = true;
    public bool back = false;

    Vector2 movement;
    Vector2 startpos;

    public int maxHealth = 80;
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
        if(count == 50){
            Invoke("attack",0.5f);
            moveTo(0,0);
            // movement.x = Random.Range(-1, 2);
            // movement.y = Random.Range(-1, 2);
        }
        else if(active && count == 20){
            float move = Random.Range(1, 5);
            if(move == 1){
                moveTo(0.8f, 0);
            }else if(move == 2){
                moveTo(-0.8f, 0);
            }else if(move == 3){
                moveTo(0,-0.8f);
            }else if(move == 4){
                moveTo(0,0.8f);
            }
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
        count = (count+1) % 100;

    }

    private void FixedUpdate() {
        float tempx = player.position.x - rb.position.x;
        float tempy = player.position.y - rb.position.y;
        float angle = Mathf.Atan2(-tempx, tempy) * Mathf.Rad2Deg;
        firePoint.rotation = angle;
        firePoint.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        //// Animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "playerbullet" || other.gameObject.tag =="Player"){
            TakeDamage( statics.GetComponent<StaticVar>().damage);
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

    void attack(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePointTransform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointTransform.up *bulletforce, ForceMode2D.Impulse);
    }

    void moveTo(float x, float y){
        movement.x = x;
        movement.y = y;
    }

    // void kill(){
    //     statics.GetComponent<StaticVar>().score++;
    // }
}
