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

public class SwipeDet : MonoBehaviour
{

    /*public float MinSwipeLength = 5f;

	private Vector3 firstPressPos;
	private Vector3 secondPressPos;
	private Vector3 currentSwipe;

	private Vector3 firstClickPos;
	private Vector3 secondClickPos;*/

	

	public Transform targetS;
	public Transform targetJ;
	public Transform Player;
	public bool Sliding, Jumping;

	//public int Lane;

	private IEnumerator jump;
	private IEnumerator slide;


    public static Swipe SwipeDirection;

    ModSwipe ms = new ModSwipe();

    void Awake()
    {
       
    }

	private void Start()
	{
		Jumping = false;
		Sliding = false;
		ms.Lane = 1;
	}

    private void Update()
	{
		DetectSwipe();

		if(ms.Lane < 0)
		{
			ms.Lane = 0;
		}else if(ms.Lane > 2)
		{
			ms.Lane = 2;
		}
	}

	public void DetectSwipe()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			ms.firstClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		}
		else
		{
			SwipeDirection = Swipe.None;
		}
		if (Input.GetMouseButtonUp(0))
		{
			ms.secondClickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			ms.currentSwipe = new Vector3(ms.secondClickPos.x - ms.firstClickPos.x, ms.secondClickPos.y - ms.firstClickPos.y);
		
			if (ms.currentSwipe.magnitude < ms.MinSwipeLength)
			{
				SwipeDirection = Swipe.None;
				return;
			}

			ms.currentSwipe.Normalize();
			
			//El personaje debe estar en 1.5 en Y!!!
			if (ms.currentSwipe.y > 0 && ms.currentSwipe.x > -0.5f && ms.currentSwipe.x < 0.5f  && Jumping == false && Sliding == false && Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Up;
				Frog.instance.Jump();
				Debug.Log("Arriba");
                targetS.transform.position = targetJ.transform.position; //Salto
                Jumping = true; //Salto

                //if (jump == null)
                //jump = Jump(); 

                StopCoroutine("Jump");//Salto
                StartCoroutine("Jump");//Salto

            }
			else if (ms.currentSwipe.y < 0 && ms.currentSwipe.x > -0.5f && ms.currentSwipe.x < 0.5f && Sliding == false && Jumping == false && Player.transform.position.y == 1.5f)
			{
				SwipeDirection = Swipe.Down;
				Frog.instance.Slide();
				Debug.Log("Abajo");
				//targetS.transform.position += new Vector3(0, -0.5f, 0);
				//Player.transform.rotation = Quaternion.Euler (-90,0,0);
				Sliding = true;

				if(slide == null)
					slide = Slide();			

				StopCoroutine("Slide");
				StartCoroutine("Slide");
				
			}
			else if (ms.currentSwipe.x < 0 && ms.currentSwipe.y > -0.5f && ms.currentSwipe.y < 0.5f && ms.Lane != 0)
			{
				SwipeDirection = Swipe.Left;
				Debug.Log("Izquierda");
				ms.Lane -= 1;
				targetS.transform.position += new Vector3(-1.5f, 0, 0);
			}
			else if (ms.currentSwipe.x > 0 && ms.currentSwipe.y > -0.5f && ms.currentSwipe.y < 0.5f && ms.Lane != 2)
				{
				SwipeDirection = Swipe.Right;
				Debug.Log("Derecha");
                ms.Lane += 1;
				targetS.transform.position += new Vector3(1.5f, 0, 0);
			} 
		}
		
	}
    // duracion de salto
	private IEnumerator Jump() //Salto
	{
		if(Jumping == false)
		{
			yield return null;
		}

		yield return new WaitForSeconds(0.4f);
		
		Frog.instance.False();
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

		Frog.instance.False();
		//targetS.transform.position += new Vector3(0, 0.5f, 0);
		//Player.transform.rotation = Quaternion.Euler (0,0,0);
		Sliding = false;
	}	
}