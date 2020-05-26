using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public int powerType;
    public StaticVar stat;

    // Start is called before the first frame update
    void Start()
    {
        if(powerType > 3 || powerType < 1)powerType = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            stat.setPowerUp(powerType);
        }
    }
}
