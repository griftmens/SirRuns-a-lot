//controlador

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	Mundo mun = new Mundo();
	//public float Speed_floor = 11f;
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
		while(mun.Speed_floor > 0)
		{
			mun.Speed_floor -= 0.01f;
		}
	} 
}
