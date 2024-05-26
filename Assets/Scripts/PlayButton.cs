using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private string gameObjectToActivateName;

    void Start(){
        gameObject.GetComponent<Button>().onClick.AddListener(OnPlayButtonClicked);
    }

    public void OnPlayButtonClicked(){
        GameManager.gameObjectToActivateName = gameObjectToActivateName;
        SceneManager.LoadScene(1);
    }
}
