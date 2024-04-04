using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    private float speed = 5.0f;
    protected Rigidbody playerRb;

    public Player()
    {
    }

    protected void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate(){
        Move();
    }
    protected abstract void Move();

    public float Speed {
        get {return speed;}
        set {speed = value;}
    }
}
