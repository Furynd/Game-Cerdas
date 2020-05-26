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
    Player player;
    string sceneName;

    static int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "MainScene"){
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.setcurHealth(curHealth);
            player.setcurMana(curMana);
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

    public void updateStat(int health, int mana)
    {
        // Debug.Log("health=" + health.ToString());
        curHealth = health;
        curMana = mana;

    }
}
