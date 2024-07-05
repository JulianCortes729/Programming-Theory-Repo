using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float forceTorque = 2000;
    private float speed = 250;
    private Rigidbody obstacleRb;
    private float leftBoundary = -3.5f;
    private float rightBoundary = 3.5f;
    private bool movinRigth;

    void Start (){
        obstacleRb = GetComponent<Rigidbody>();

        if(gameObject.name == "Obstacle_2"){
            movinRigth = false;
        }else{
            movinRigth = true;
        }

    }

    void Update()
    {
        Move();//ABSTRACTION
    }

    void Move(){//ABSTRACTION

        float moveDirection = movinRigth ? 1 : -1;

        obstacleRb.AddTorque(forceTorque * Vector3.forward * Time.deltaTime ,ForceMode.Acceleration);
        
        obstacleRb.AddForce(moveDirection*speed*Time.deltaTime*Vector3.right, ForceMode.Acceleration);

        if(transform.position.x > rightBoundary){
            movinRigth = false;
        }else if(transform.position.x < leftBoundary){
            movinRigth = true;
        }

    }
}
