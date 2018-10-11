﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform player;

    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        //float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 5 /*&& angle < 30*/)
        {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if(direction.magnitude > 2)
            {
                this.transform.Translate(0, 0, 0.05f);
            }

        }
    }
}