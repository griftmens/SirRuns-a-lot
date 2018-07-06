//movimiento de bloques

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    
	Transform Move;
	public static Movement instance;
	public float speedfloor; //no sirve

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		Move = GetComponent<Transform>();
        speedfloor = GameController.instance.speed_floor;
		
	}
	
	// Update is called once per frame
	void Update () {

        speedfloor = GameController.instance.speed_floor;
		Move.transform.position += new Vector3(0,0,-speedfloor) * Time.deltaTime;
		
	}
	 
	public void DeAccel()
	{
        speedfloor -= 0.01f;
	} 
	public void Halt()
	{
        speedfloor = 0;
	}

	
}
