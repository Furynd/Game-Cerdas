using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSspawner : MonoBehaviour
{
    public int openingDir;
    private bool spawned = false;
    private int rand;
    private RoomTemplate templates;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();    
        Invoke("Spawn",0.5f);
    }
    
    void Spawn()
    {
        if(spawned == false){
            if(openingDir == 0){
                rand = Random.Range(0,templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            } else if(openingDir == 1){
                rand = Random.Range(0,templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } else if(openingDir == 2){
                rand = Random.Range(0,templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            } else if(openingDir == 3){
                rand = Random.Range(0,templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("roomspawn")){
            // if(other.GetComponent<RoomSspawner>().spawned == false && spawned == false){
                // Instantiate(templates.closedRoom, transform.position, templates.closedRoom.transform.rotation);
                // Destroy(gameObject);
            // }
            spawned = true;
            Debug.Log("123");
        }
    }
}
