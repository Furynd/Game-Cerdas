﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] closerRoom;

    public StaticVar stat;

    public bool portal = false;
    public int roomCnt = 0;
    public int roomPred = 0;
    public int roomMax = 5;
    
    void Start(){
        roomMax = 5 + stat.getLevel(); 
    }
    void Update()
    {
        
    }
}
