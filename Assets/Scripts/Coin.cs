using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public Text textScore;
    private int score;
	// Use this for initialization
	void Start () {
        textScore.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0,0,100*Time.deltaTime);
        textScore.text = "" + score;
		
	}

    private void OnTriggerEnter(Collider other)
    {
        score = score + 1;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(this);
    }
}
