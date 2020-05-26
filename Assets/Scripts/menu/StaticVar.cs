using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StaticVar : MonoBehaviour
{
    static int score = 0;
    static int curHealth = 100;
    static int curMana = 0;
    // Player player;
    GameObject player;
    string sceneName;
    SpriteRenderer powerSurge;
    
    public int maxhealth;
    public float manaRegen;
    public int damage;

    static int powerup;

    static int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        powerSurge = GameObject.FindGameObjectWithTag("powerSurge").GetComponent<SpriteRenderer>();

         if(powerup == 1){//power up
            powerSurge.enabled = (true);
            powerSurge.color = new Color(255,0,0);
            damage = 50;
            maxhealth = 100;
            manaRegen = 0.5f;
        } else if(powerup == 2)//health up
        {
            powerSurge.enabled = (true);
            powerSurge.color = new Color(0,255,0);
            damage = 40;
            maxhealth = 120;
            manaRegen = 0.5f;
        } else if(powerup == 3)//mana regen up
        {
            powerSurge.enabled = (true);
            powerSurge.color = new Color(0,0,255);
            damage = 40;
            maxhealth = 100;
            manaRegen = 0.4f;
        } else{ // normal 
            powerSurge.enabled = (false);
            damage = 40;
            maxhealth = 100;
            manaRegen = 0.5f;
        }


        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "MainScene"){
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().setMaxHealth(maxhealth);
            if(level == 0)curHealth = maxhealth;
            player.GetComponent<Player>().setcurHealth(curHealth);
            player.GetComponent<Player>().setcurMana(curMana);
            level++;
        }
        if(sceneName == "LobbyScene"){
            score = 0;
            level = 0;
        }
        //  = curScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(score);
        if(sceneName == "MainScene")
        {
            TextMeshProUGUI scoreText;
            scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<TextMeshProUGUI>();
            scoreText.text = "score: " + score.ToString();
        }
        
    }

    public void addScore(int add)
    {
        score += add;
        // Debug.Log(score);
    }

    public int getScore()
    {
        return score;
    }

    public int getLevel(){
        return level;
    }

    public void setPowerUp(int a){
        powerup = a;
        
        Debug.Log("a " + a.ToString());
        if(powerup == 1){//power up
            powerSurge.enabled = (true);
            powerSurge.color = new Color(255,0,0);
            damage = 50;
            maxhealth = 100;
            manaRegen = 0.5f;
        } else if(powerup == 2)//health up
        {
            powerSurge.enabled = (true);
            powerSurge.color = new Color(0,255,0);
            damage = 40;
            maxhealth = 120;
            manaRegen = 0.5f;
        } else if(powerup == 3)//mana regen up
        {
            powerSurge.enabled = (true);
            powerSurge.color = new Color(0,0,255);
            damage = 40;
            maxhealth = 100;
            manaRegen = 0.4f;
        } else{ // normal 
            powerSurge.enabled = (false);
            damage = 40;
            maxhealth = 100;
            manaRegen = 0.5f;
        }
    }

    public void updateStat(int health, int mana)
    {
        // Debug.Log("health=" + health.ToString());
        curHealth = health;
        curMana = mana;

    }
}
