using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public int sceneNumber= 1; // The build index of the scene you want to load

    public void GoToSceneByNumber()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene(1);
    }
}


