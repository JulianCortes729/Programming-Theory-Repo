using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
   
    public void OnQuitButtonClicked(){
        Application.Quit();

        // Para asegurarse de que la aplicación se cierra durante el desarrollo en el editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
