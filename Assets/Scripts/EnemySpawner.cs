using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    private int enemyNum;

    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        enemyNum = Random.Range(1,5);
        for (int i = 0; i < enemyNum; i++)
        {
            pos.x = Random.Range(1,3)+ transform.position.x;
            pos.y = Random.Range(1,3)+ transform.position.y;
            Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
