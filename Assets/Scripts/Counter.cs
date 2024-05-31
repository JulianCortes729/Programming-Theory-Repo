using UnityEngine;

public class Counter : MonoBehaviour
{
    private GameManager gameManager;
      void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Ball_1" || collision.gameObject.name == "Ball_2"){
            if(gameObject.name == "Wall_1"){
                gameManager.AddPointToPlayer2();
            }
            if(gameObject.name == "Wall_2"){
                gameManager.AddPointToPlayer1();
            }
        }
    }
}
