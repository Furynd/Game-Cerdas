using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public StaticVar stat;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(sceneName == "MainScene")
                stat.updateStat(other.gameObject.GetComponent<Player>().currentHealth,
                                  other.gameObject.GetComponent<Player>().currentMana);
            SceneManager.LoadScene("MainScene");
        }
    }
}
