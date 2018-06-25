//swipe del jugador

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Swipe
{
	None,
	Up,
	Down,
	Left,
	Right,
}

public class Register 
{

    /*public float MinSwipeLength = 5f;

	private Vector3 firstPressPos;
	private Vector3 secondPressPos;
	private Vector3 currentSwipe;

	private Vector3 firstClickPos;
	private Vector3 secondClickPos;

	

	public Transform targetS;
	public Transform targetJ;
	public Transform Player;
	public bool Sliding, Jumping;

	public int Lane;*/

	private IEnumerator jump;
	private IEnumerator slide;


    Entidades ent = new Entidades();

    public static Swipe SwipeDirection;

    void Awake()
    {
       
    }

	private void Start()
	{
		ent.Jumping = false;
		ent.Sliding = false;
		ent.Lane = 1;
	}
	
	private void Update()
	{
		DetectSwipe();

		if(ent.Lane < 0)
		{
			ent.Lane = 0;
		}else if(ent.Lane > 2)
		{
			ent.Lane = 2;
		}
	}

	public void DetectSwipe()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			ent.firstClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		}
		else
		{
			SwipeDirection = Swipe.None;
		}
		if (Input.GetMouseButtonUp(0))
		{
			ent.secondClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			ent.currentSwipe = new Vector3(ent.secondClickPos.x - ent.firstClickPos.x, ent.secondClickPos.y - ent.firstClickPos.y);
		
			if (ent.currentSwipe.magnitude < ent.MinSwipeLength)
			{
				SwipeDirection = Swipe.None;
				return;
			}

			ent.currentSwipe.Normalize();
			
			if (ent.currentSwipe.y > 0 && ent.currentSwipe.x > -0.5f && ent.currentSwipe.x < 0.5f  && ent.Jumping == false && ent.Sliding == false && ent.Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Up;
				Debug.Log("Arriba");
				ent.targetS.transform.position = ent.targetJ.transform.position;
				ent.Jumping = true;

				if (jump == null)
					jump = Jump();
				
				Helper.instance.StopCoroutine(jump);
				Helper.instance.StartCoroutine(jump);
				
			}
			else if (ent.currentSwipe.y < 0 && ent.currentSwipe.x > -0.5f && ent.currentSwipe.x < 0.5f && ent.Sliding == false && ent.Jumping == false && ent.Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Down;
				Debug.Log("Abajo");
				ent.targetS.transform.position += new Vector3(0, -0.5f, 0);
				ent.Player.transform.rotation = Quaternion.Euler (-90,0,0);
				ent.Sliding = true;

				if(slide == null)
					slide = Slide();			

				Helper.instance.StopCoroutine(slide);
				Helper.instance.StartCoroutine(slide);
				
			}
			else if (ent.currentSwipe.x < 0 && ent.currentSwipe.y > -0.5f && ent.currentSwipe.y < 0.5f && ent.Lane != 0)
			{
				SwipeDirection = Swipe.Left;
				Debug.Log("Izquierda");
				ent.Lane -= 1;
				ent.targetS.transform.position += new Vector3(-1.5f, 0, 0);
			}
			else if (ent.currentSwipe.x > 0 && ent.currentSwipe.y > -0.5f && ent.currentSwipe.y < 0.5f && ent.Lane != 2)
				{
				SwipeDirection = Swipe.Right;
				Debug.Log("Derecha");
				ent.Lane += 1;
				ent.targetS.transform.position += new Vector3(1.5f, 0, 0);
			} 
		}
		
	}
    // duracion de salto
	private IEnumerator Jump()
	{
		if(ent.Jumping == false)
		{
			yield return null;
		}

		yield return new WaitForSeconds(0.4f);
		
		ent.targetS.transform.position = new Vector3(ent.targetS.transform.position.x,1.5f,ent.targetS.transform.position.z);
		ent.Jumping = false;
	}

    // duracion de slide
	private IEnumerator Slide()
	{
		if(ent.Sliding == false)
		{
			yield return null;
		}
		
		yield return new WaitForSeconds(0.5f);

		ent.targetS.transform.position += new Vector3(0, 0.5f, 0);
		ent.Player.transform.rotation = Quaternion.Euler (0,0,0);
		ent.Sliding = false;
	}	
}