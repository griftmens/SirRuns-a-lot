using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

	public enum Swipe
	{
	None,
	Up,
	Down,
	Left,
	Right,
	}

	public static PlayerModel instance;

	void Awake()
	{
		instance = this;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		
	}
}
