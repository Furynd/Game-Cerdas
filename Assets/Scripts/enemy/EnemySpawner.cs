using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject REnemyPrefab;
    private int enemyNum;
    private int enemyType;
    public bool active = false;
    public bool spawned = false;
    private StaticVar stat;
    // private List<GameObject> enemies;

    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.FindGameObjectWithTag("Statics").GetComponent<StaticVar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active && !spawned)
        {
            int maxEnemy = 5 + stat.getLevel()/5;
            enemyNum = Random.Range(1,maxEnemy);
            for (int i = 0; i < enemyNum; i++)
            {
                enemyType = Random.Range(1,5);
                pos.x = Random.Range(1,3)+ transform.position.x;
                pos.y = Random.Range(1,3)+ transform.position.y;
                GameObject temp;
                if(enemyType < 3)
                    temp = Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
                else temp = Instantiate(REnemyPrefab, pos, REnemyPrefab.transform.rotation);
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
