using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

	public Animator anim;

	public static Frog instance;

	public Transform Player;

	
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);
		
	}

	public void Jump()
	{
		anim.SetBool("Jump", true);
	}

	public void Slide()
	{
		anim.SetBool("Slide", true);
	}

	public void Death()
	{
		anim.Play("death");
	}

	public void False()
	{
		anim.SetBool("Jump", false);
		anim.SetBool("Slide", false);
	}
}
