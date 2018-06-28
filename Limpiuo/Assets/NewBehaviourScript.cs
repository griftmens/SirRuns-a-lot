using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float v = 1f;

	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody>().velocity = Vector3.down * v;
		
		Physics.gravity *= 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		GetComponent<Rigidbody>().AddForce (Vector3.up * v, ForceMode.Impulse);
		
	}
}
