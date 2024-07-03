using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI counterText_1 ;
    private TextMeshProUGUI counterText_2 ;
    private TextMeshProUGUI textWin;
    private GameObject winnerBanner;
    private Button restartButton;

    private int count_1 = 0;
    private int count_2 = 0;

    private int maxPoints = 11;

    [SerializeField]
    private GameObject ball1;

    [SerializeField]
    private GameObject ball2;

    [SerializeField]
    private GameObject menu;

    public static GameManager Instance { get; private set;}
    
    private void Awake(){

        if(Instance != null && Instance != this){
            Destroy(gameObject);
            Destroy(ball1);
            Destroy(ball2);
            Destroy(menu);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(ball1);
        DontDestroyOnLoad(ball2);
        DontDestroyOnLoad(menu);
    }
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
            ShowWinnerBanner("GREEN");
            ChangeColor(textWin,Color.green);
            PauseGame();
        }
        else if (count_2 >= maxPoints){
            ShowWinnerBanner("RED");
            ChangeColor(textWin,Color.red);
            PauseGame();
        }
    }

    void ShowWinnerBanner(String winner){
        textWin.text = $@"{winner}" + textWin.text;
        winnerBanner.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        count_1 = 0;
        count_2 = 0;
        Time.timeScale = 1;
        ball1.SetActive(false);
        ball2.SetActive(false);
        UpdateScoreUI();
    }

    void PauseGame()
    {
        // Detiene el tiempo del juego
        Time.timeScale = 0;
    }

     public void OnPlayButtonEasyClicked(){

       StartCoroutine(ActivateBall(ball1, true));
       StartCoroutine(ActivateBall(ball2, false)); 
       SceneManager.LoadScene(1);
       menu.SetActive(false);
        
       
    }

    public void OnPlayButtonHardClicked(){
        StartCoroutine(ActivateBall(ball1, false));
        StartCoroutine(ActivateBall(ball2, true));
        SceneManager.LoadScene(1);
        menu.SetActive(false);
       
      
    }

    public void OnQuitButtonClicked(){
        Application.Quit();

        // Para asegurarse de que la aplicación se cierra durante el desarrollo en el editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OnRestartButtonClicked(){
        ResetGame();
        SceneManager.LoadScene(0);
        menu.SetActive(true);
    }

   
    private IEnumerator ActivateBall(GameObject ball, bool state)
    {
        yield return new WaitForSeconds(0.1f); // Espera un momento para asegurarse de que la escena se haya cargado completamente
        ball.SetActive(state);
    }


    void ChangeColor(TextMeshProUGUI text, Color color){
        if(text!=null){
            text.color = color;
        }
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
    public Button RestartButton
    {
        set{restartButton = value;}
        get{return restartButton;}
    }

}
