using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameObjectToActivateName;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}
