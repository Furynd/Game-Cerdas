using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    private int enemyNum;
    public bool active = false;
    public bool spawned = false;
    // private List<GameObject> enemies;

    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active && !spawned)
        {
            enemyNum = Random.Range(1,5);
            for (int i = 0; i < enemyNum; i++)
            {
                pos.x = Random.Range(1,3)+ transform.position.x;
                pos.y = Random.Range(1,3)+ transform.position.y;
                GameObject temp;
                temp = Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
                // temp.GetComponent<enemy>().setActive(true);
                // enemies.Add(temp);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            active = true;
            // foreach (var a in enemies)
            // {
            //     a.GetComponent<enemy>().setActive(active);
            // }
        }
        if(other.gameObject.tag == "Enemy"){
            // enemies.Add(other.gameObject);
            // other.gameObject.GetComponent<enemy>().setActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        // if(other.gameObject.tag == "Enemy"){
        //     other.gameObject.GetComponent<enemy>().setActive(active);
        // }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // if(other.gameObject.tag == "Enemy"){
        //     other.gameObject.GetComponent<enemy>().setActive(false);
        // }
    }
}
