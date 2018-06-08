//controlador

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public float Speed = 11f;
	public static GameController instance;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeAccel()
	{
		while(Speed > 0)
		{
			Speed -= 0.01f;
		}
	} 
}
