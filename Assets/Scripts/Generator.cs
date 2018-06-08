//Generacion de mundo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject[] Template;
	public static Generator instance;

	
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		InvokeRepeating("Spawn",1.25f,1.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		Instantiate(Template[Random.Range(0,8)], transform.position, transform.rotation);
	}
}
