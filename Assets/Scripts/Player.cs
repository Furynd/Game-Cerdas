using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int maxMana = 100;
    public int currentMana;
    public HealthBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        
        currentMana = maxMana;
        manaBar.setMaxHealth(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        if(currentHealth <= 0){
            SceneManager.LoadScene("MenuScene");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }
}
