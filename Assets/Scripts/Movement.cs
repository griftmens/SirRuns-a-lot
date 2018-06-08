//movimiento de bloques

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Transform Move;
	public static Movement instance;
	public float Speed = 0.2f;

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

		Move.transform.position += new Vector3(0,0,-GameController.instance.Speed) * Time.deltaTime;
		
	}
	 
	public void DeAccel()
	{
		GameController.instance.Speed -= 0.01f;
	} 
	public void Halt()
	{
		GameController.instance.Speed = 0;
	}

	
}
