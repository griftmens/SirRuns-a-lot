using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        //textScore.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 100 * Time.deltaTime, 0);
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Score.instance.scores = Score.instance.scores + 1;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(this);
    }
}
