// no se usa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    bool pause = false;
    public Image PMenu;
    public Image Resume;
    public Image Exit;

    // Use this for initialization
    void Start () {

        PMenu.enabled = false;
        Resume.enabled = false;
        Exit.enabled = false;
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
}
