using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float forceTorque = 2000;
    private Rigidbody obstacleRb;

    void Start (){
        obstacleRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move(){
        obstacleRb.AddTorque(forceTorque * Vector3.forward * Time.deltaTime ,ForceMode.Acceleration);
    }
}
