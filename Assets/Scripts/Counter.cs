using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counterText_1;

    [SerializeField]
    private TextMeshProUGUI counterText_2;
    private int count_1;
    private int count_2;
    void Start()
    {
        count_1 = 0;
        count_2 = 0;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Ball_1" || collision.gameObject.name == "Ball_2"){
            if(gameObject.name == "Wall_1"){
                count_2++;
                counterText_2.text = count_2.ToString();
            }
            if(gameObject.name == "Wall_2"){
                count_1++;
                counterText_1.text = count_1.ToString();
            }
        }
    }
}
