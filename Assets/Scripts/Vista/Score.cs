using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score instance;
    public Text textScores;
    public int scores;

    private void Awake()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        textScores.text = scores.ToString();
    }


    
}
