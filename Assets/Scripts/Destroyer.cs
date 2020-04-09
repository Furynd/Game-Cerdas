using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("roomspawn")){
            // other.RoomSspawner.setSpawned();
            // Destroy(other.gameObject);
            Debug.Log("Tes");
        }
    }
}
