﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    public void PlayGame()
    {
        Debug.Log("entra");
        SceneManager.LoadScene("00-Test");
    }

    public void QuitGame()
    {
        Debug.Log("Sale");
        SceneManager.LoadScene("MainMenu");
    }

    public void Lose()
    {
        Debug.Log("Perdiste");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
