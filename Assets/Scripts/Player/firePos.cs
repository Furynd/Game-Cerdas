﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePos : MonoBehaviour
{
    // public Transform pos;
    // Update is called once per frame
    public Rigidbody2D rb;
    void Update()
    {
    }

    public void setRot(float rot){
        rb.rotation = rot;
    }
}
