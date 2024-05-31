using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_1 ;
    
    [SerializeField]
    private TextMeshProUGUI text_2 ;

    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        StartScoring();
        // Verifica si hay un GameObject que debe ser activado
        if (!string.IsNullOrEmpty(GameManager.gameObjectToActivateName))
        {
            GameObject obj = GameObject.Find(GameManager.gameObjectToActivateName);
            if (obj != null)
            {
                if(obj.name == "Ball_1"){
                    GameObject.Find("Ball_2").SetActive(false);
                }
                if(obj.name == "Ball_2"){
                    GameObject.Find("Ball_1").SetActive(false);
                }
            }
            else
            {
                Debug.LogWarning("GameObject not found: " + GameManager.gameObjectToActivateName);
            }
            // Limpia la variable para evitar activar el mismo objeto en futuras escenas
            GameManager.gameObjectToActivateName = null;
        }
    }


    public void StartScoring(){
        gameManager.CounterText_1 = text_1;
        gameManager.CounterText_2 = text_2;
    }

}
