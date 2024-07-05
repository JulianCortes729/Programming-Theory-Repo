using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//INHERITANCE
public class Player2 : Player
{
    protected new void Start() => base.Start();
    

    //POLYMORPHISM
    protected override void Move(){
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
            float moveVertical = Input.GetAxis("Vertical2");
            playerRb.AddForce(Vector3.up * moveVertical * Speed * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}
