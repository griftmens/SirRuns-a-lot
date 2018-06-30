//movimiento de bloques

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    
	Transform Move;
	public static Movement instance;
	public float Speed_floor = 0.2f; //no sirve

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		Move = GetComponent<Transform>();
		Speed_floor = GameController.instance.Speed_floor;
		
	}
	
	// Update is called once per frame
	void Update () {

		Speed_floor = GameController.instance.Speed_floor;
		Move.transform.position += new Vector3(0,0,-Speed_floor) * Time.deltaTime;
		
	}
	 
	public void DeAccel()
	{
		Speed_floor -= 0.01f;
	} 
	public void Halt()
	{
		Speed_floor = 0;
	}

	
}
