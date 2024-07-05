using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    private Vector3 movement;
    private float speed;
    public Ball(){}

    protected void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        Move();//ABSTRACTION
    }
    protected void Update()
    {
        ballRb.velocity = movement * speed;
    }

    protected void Move(){//ABSTRACTION
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = Random.Range(0,2) == 0 ? -1 : 1;
        Movement = new Vector3(randomX,Movement.y,Movement.z);
        Movement = new Vector3(Movement.x,randomY,Movement.z);  
    }

    protected IEnumerator OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "BallCollision"){
            Movement = Vector3.Reflect(Movement, col.contacts[0].normal); 
        }
        if(col.gameObject.tag == "Wall2" || col.gameObject.tag == "Wall1"){
            gameObject.transform.position = Vector3.zero;
            ballRb.isKinematic = true;
            yield return new WaitForSecondsRealtime(1);
            Move();
            ballRb.isKinematic = false;
        }
    }  

    //ENCAPSULATION
    public Rigidbody BallRb {
        get { return ballRb; }
        set { ballRb = value; }
    }

    public Vector3 Movement {
        get { return movement; }
        set { movement = value; }
    }
   
    public float Speed {
        get { return speed; }
        set { speed = value; }
    }
}
