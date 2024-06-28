using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private string gameObjectToActivateName;
    private TextMeshProUGUI counterText_1 ;
    private TextMeshProUGUI counterText_2 ;
    private TextMeshProUGUI textWin;
    private GameObject winnerBanner;
    private Button buttonRestart;

    private int count_1 = 0;
    private int count_2 = 0;

    private int maxPoints = 11;

    public static GameManager Instance { get; private set;}

    private void Awake()
    {
        // Singleton Pattern: Asegura que solo exista una instancia de GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruir el nuevo GameManager creado
        }
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
            PauseGame();
        }
        else if (count_2 >= maxPoints){
            ShowWinnerBanner("RED");
            PauseGame();
        }
    }

    void ShowWinnerBanner(String winner){
        textWin.text = $@"{winner}" + textWin.text;
        winnerBanner.gameObject.SetActive(true);
    }

    public void OnPlayButtonEasyClicked(){
        gameObjectToActivateName = "Ball_1";
        SceneManager.LoadScene(1);
    }

     public void OnPlayButtonHardClicked(){
        gameObjectToActivateName = "Ball_2";
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked(){
        Application.Quit();

        // Para asegurarse de que la aplicación se cierra durante el desarrollo en el editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OnRestartButtonClicked(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        count_1 = 0;
        count_2 = 0;
    }

    void PauseGame()
    {
        // Detiene el tiempo del juego
        Time.timeScale = 0;
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

    public Button ButtonRestart{
        set{buttonRestart = value;}
        get{ return buttonRestart;}
    }

    public string GameObjectToActivateName{
        set{gameObjectToActivateName=value;}
        get{return gameObjectToActivateName;}
    }
}
