using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameObjectToActivateName;
    private TextMeshProUGUI counterText_1 ;
    private TextMeshProUGUI counterText_2 ;
    private TextMeshProUGUI textWin;
    private GameObject winnerBanner;

    private int count_1 = 0;
    private int count_2 = 0;

    private int maxPoints = 11;

    public void AddPointToPlayer1()
    {
        count_1++;
        CheckForWinner();
        UpdateScoreUI();
    }


    public void AddPointToPlayer2()
    {
        count_2++;
        CheckForWinner();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (counterText_1 != null)
        {
            counterText_1.text = count_1.ToString();
        }

        if (counterText_2 != null)
        {
            counterText_2.text = count_2.ToString();
        }
        
    }

    void CheckForWinner(){
        if (count_1 >= maxPoints){
            //Debug.Log("Player Green win");
            ShowWinnerBanner("GREEN");
        }
        else if (count_2 >= maxPoints){
            //Debug.Log("Player Red win");
            ShowWinnerBanner("RED");
        }
    }

    void ShowWinnerBanner(String winner){
        textWin.text = $@"{winner}" + textWin.text;
        winnerBanner.gameObject.SetActive(true);
    }



    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public TextMeshProUGUI CounterText_1
    {
        set{counterText_1 = value;}
        get{return counterText_1;}
    }
    public TextMeshProUGUI CounterText_2
    {
        set{counterText_2 = value;}
        get{return counterText_2;}
    }

    public TextMeshProUGUI TextWin
    {
        set{textWin = value;}
        get{return textWin;}
    }

    public GameObject WinnerBanner
    {
        set{winnerBanner = value;}
        get{return winnerBanner;}
    }




}
