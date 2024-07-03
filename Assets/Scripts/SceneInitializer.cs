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

    void Start()
    {
        StartScoring();
        buttonRestart.onClick.AddListener(GameManager.Instance.OnRestartButtonClicked);
    }

    public void StartScoring(){
        GameManager.Instance.CounterText_1 = text_1;
        GameManager.Instance.CounterText_2 = text_2;
        GameManager.Instance.TextWin = text_3;
        GameManager.Instance.WinnerBanner = winnerBanner;
        GameManager.Instance.RestartButton = buttonRestart;
    }

}
