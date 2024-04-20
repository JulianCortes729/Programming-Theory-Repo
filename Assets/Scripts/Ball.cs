using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private Rigidbody ballRb;
    private Vector3 movement = Vector3.zero;

    private float speed = 5.0f;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        Move();

    }
    void FixedUpdate()
    {
        ballRb.velocity = movement * speed;
    }

    void Move(){
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = Random.Range(0,2) == 0 ? -1 : 1;
        movement.x = randomX;
        movement.y = randomY;    
    }
    
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "BallCollision"){
            movement = Vector3.Reflect(movement, col.contacts[0].normal); 
        }
    }
    
   
}
