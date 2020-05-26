using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    public StaticVar  stat;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        t.text = "Score : " + stat.getScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
