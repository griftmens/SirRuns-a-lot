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

public class Register : MonoBehaviour
{
	public float MinSwipeLength = 5f;

	private Vector3 firstPressPos;
	private Vector3 secondPressPos;
	private Vector3 currentSwipe;

	private Vector3 firstClickPos;
	private Vector3 secondClickPos;

	public static Swipe SwipeDirection;

	public Transform targetS;
	public Transform targetJ;
	public Transform Player;
	public bool Sliding, Jumping;

	public int Lane;

	void Awake()
    {
       
    }

	private void Start()
	{
		Jumping = false;
		Sliding = false;
		Lane = 1;
	}
	
	private void Update()
	{
		DetectSwipe();

		if(Lane < 0)
		{
			Lane = 0;
		}else if(Lane > 2)
		{
			Lane = 2;
		}
	}

	public void DetectSwipe()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			firstClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		}
		else
		{
			SwipeDirection = Swipe.None;
		}
		if (Input.GetMouseButtonUp(0))
		{
			secondClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
		
			if (currentSwipe.magnitude < MinSwipeLength)
			{
				SwipeDirection = Swipe.None;
				return;
			}

			currentSwipe.Normalize();
			
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f  && Jumping == false && Sliding == false && Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Up;
				Debug.Log("Arriba");
				targetS.transform.position = targetJ.transform.position;
				Jumping = true;
				StopCoroutine("Jump");
				StartCoroutine("Jump");
				
			}
			else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && Sliding == false && Jumping == false && Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Down;
				Debug.Log("Abajo");
				targetS.transform.position += new Vector3(0, -0.5f, 0);
				Player.transform.rotation = Quaternion.Euler (-90,0,0);
				Sliding = true;
				StopCoroutine("Slide");
				StartCoroutine("Slide");
			}
			else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && Lane != 0)
			{
				SwipeDirection = Swipe.Left;
				Debug.Log("Izquierda");
				Lane -= 1;
				targetS.transform.position += new Vector3(-1.5f, 0, 0);
			}
			else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && Lane != 2)
				{
				SwipeDirection = Swipe.Right;
				Debug.Log("Derecha");
				Lane += 1;
				targetS.transform.position += new Vector3(1.5f, 0, 0);
			} 
		}
		
	}
    // duracion de salto
	private IEnumerator Jump()
	{
		if(Jumping == false)
		{
			yield return null;
		}

		yield return new WaitForSeconds(0.4f);
		
		targetS.transform.position = new Vector3(targetS.transform.position.x,1.5f,targetS.transform.position.z);
		Jumping = false;
	}

    // duracion de slide
	private IEnumerator Slide()
	{
		if(Sliding == false)
		{
			yield return null;
		}
		
		yield return new WaitForSeconds(0.5f);

		targetS.transform.position += new Vector3(0, 0.5f, 0);
		Player.transform.rotation = Quaternion.Euler (0,0,0);
		Sliding = false;
	}	
}