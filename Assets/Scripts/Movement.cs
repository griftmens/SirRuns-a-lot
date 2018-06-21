//movimiento de bloques

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Mundo mun = new Mundo();
	Transform Move;
	public static Movement instance;
	//public float Speed = 0.2f; //no sirve

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		Move = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

		Move.transform.position += new Vector3(0,0,-mun.Speed_floor) * Time.deltaTime;
		
	}
	 
	public void DeAccel()
	{
		mun.Speed_floor -= 0.01f;
	} 
	public void Halt()
	{
		mun.Speed_floor = 0;
	}

	
}
