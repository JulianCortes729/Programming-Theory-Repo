using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SceneInitializer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_1 ;
    
    [SerializeField]
    private TextMeshProUGUI text_2 ;

    [SerializeField]
    private TextMeshProUGUI text_3;

    [SerializeField]
    private GameObject winnerBanner;

    [SerializeField]
    private Button buttonRestart;

    //private GameManager gameManager;
    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        
        StartScoring();
        // Verifica si hay un GameObject que debe ser activado
        if (!string.IsNullOrEmpty(GameManager.Instance.GameObjectToActivateName))
        {
            GameObject obj = GameObject.Find(GameManager.Instance.GameObjectToActivateName);
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
                Debug.LogWarning("GameObject not found: " + GameManager.Instance.GameObjectToActivateName);
            }
            // Limpia la variable para evitar activar el mismo objeto en futuras escenas
            GameManager.Instance.GameObjectToActivateName = null;
        }
        buttonRestart.onClick.AddListener(GameManager.Instance.OnRestartButtonClicked);
    }


    public void StartScoring(){
        GameManager.Instance.CounterText_1 = text_1;
        GameManager.Instance.CounterText_2 = text_2;
        GameManager.Instance.TextWin = text_3;
        GameManager.Instance.WinnerBanner = winnerBanner;
        GameManager.Instance.ButtonRestart = buttonRestart;
    }

}
