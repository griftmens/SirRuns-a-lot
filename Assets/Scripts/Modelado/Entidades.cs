using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entidades  {

    public float MinSwipeLength = 5f;

    public Vector3 firstPressPos;
    public Vector3 secondPressPos;
    public Vector3 currentSwipe;

    public Vector3 firstClickPos;
    public Vector3 secondClickPos;



    public Transform targetS;
    public Transform targetJ;
    public Transform Player;
    public bool Sliding, Jumping;

    public int Lane;

    public Transform Target_origin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
