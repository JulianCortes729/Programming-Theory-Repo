using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player1 : Player
{
    

    protected new void Start() => base.Start();

    protected override void Move()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){

            float moveVertical = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.up * Speed * moveVertical * Time.deltaTime, ForceMode.Acceleration);
        }
        
    }
    
}
