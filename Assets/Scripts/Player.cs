using UnityEngine;


public abstract class Player : MonoBehaviour
{

    private float speed = 3000.0f;
    protected Rigidbody playerRb;

    public Player()
    {
    }

    protected void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    protected void Update(){
        Move();
    }
    protected abstract void Move();

    //ENCAPSULATION
    public float Speed {
        get {return speed;}
        set {speed = value;}
    }
}
