using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    protected new void Start() => base.Start();
    
    protected override void Move(){
        if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && gameObject.CompareTag("Player2")){
            float moveVertical = Input.GetAxis("Vertical2");
            playerRb.AddForce(Vector3.up * moveVertical * Speed);
        }
    }
}