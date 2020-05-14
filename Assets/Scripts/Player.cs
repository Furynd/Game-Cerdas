using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;
    public static bool begin = true;

    public int maxMana = 100;
    public int currentMana;
    public HealthBar manaBar;
    public float manaRegen = 1.0f;
    private float nextRegen=0;

    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(begin);
        // if(currentHealth > 100 && currentHealth <= 0)
        if(begin || currentHealth <= 0){
            currentHealth = maxHealth;
            begin = false;
            Debug.Log(begin);
        }
        healthBar.setMaxHealth(maxHealth);
        
        currentMana = 0;
        manaBar.setMaxHealth(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Attack();
        // }
        if(currentHealth <= 0){
            SceneManager.LoadScene("MenuScene");
        }

        if(currentMana < maxMana && Time.time >= nextRegen)
        {
            nextRegen = Time.time + manaRegen;
            currentMana += 1;
            manaBar.setHealth(currentMana);
        }    
        else if(currentMana > maxMana){
            currentMana = maxMana;
            manaBar.setHealth(currentMana);
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public bool UseMana(int size)
    {
        if(currentMana > size)
        {
            currentMana -= size;
            manaBar.setHealth(currentMana);
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    void Attack(){
        // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.up *bulletforce, ForceMode2D.Impulse);
    }
}
