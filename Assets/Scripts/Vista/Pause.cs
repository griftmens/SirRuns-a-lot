// no se usa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public static Pause instance;

    bool pause = false;
    public Image PMenu;
    public Image Resume;
    public Image Exit;
    public Image GameOver;
    public Image Retry;
    public Image ExitGame;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        PMenu.enabled = false;
        Resume.enabled = false;
        Exit.enabled = false;
        GameOver.enabled = false;
        Retry.enabled = false;
        ExitGame.enabled = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Pausa()
    {
        if (pause == false)
        {
            PMenu.enabled = true;
            Resume.enabled = true;
            Exit.enabled = true;
            Time.timeScale = 0;
            pause = true;
        }
        else
        {
            PMenu.enabled = false;
            Resume.enabled = false;
            Exit.enabled = false;
            Time.timeScale = 1;
            pause = false;
        }

    }

    public void Play()
    {
        PMenu.enabled = false;
        Resume.enabled = false;
        Exit.enabled = false;
        Time.timeScale = 1;
        pause = false;
    }

    public void GameO()
    {
        GameOver.enabled = true;
        Retry.enabled = true;
        ExitGame.enabled = true;
    }
}
