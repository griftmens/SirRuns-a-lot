using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static Transform playerRef;
	
	public float transitionSpeed = 1f;

	private Player playerInfo;
	private Rigidbody rb;

	private Vector3 startPos;
	private Vector3 targetPos;
	private bool moving;
	private float t;

	void Start () {
		playerInfo = new Player(1, "Rana", 5f, 10f);
		playerRef = transform;
		rb = GetComponent<Rigidbody>();
		SetPosition();
	}
	
	void Update () {
		if (moving) {
			t += Time.deltaTime;
			Vector3.Lerp(startPos, targetPos, t * transitionSpeed);
			if (Vector3.Distance(startPos,targetPos) <= 0.1f){
				moving = false;
				t = 0;
			}
		}
	}

	void SetPosition () {
		startPos = transform.position;
		targetPos = LevelManager.instance.lines[playerInfo.currentLine].position;
		moving = true;
	}

	public void Receptor (string command){

		switch (command) {
			case "Up":
				rb.AddForce (Vector3.up * playerInfo.jumpForce, ForceMode.Impulse);
				//Anim
			break;
			case "Down":
				//Slide Anim
			break;
			case "Left":
				playerInfo.currentLine--;
				if (playerInfo.currentLine < 0) playerInfo.currentLine = 0;
				//Anim
				SetPosition();
			break;
			case "Right":
				playerInfo.currentLine++;
				if (playerInfo.currentLine >= LevelManager.instance.lines.Length) playerInfo.currentLine = LevelManager.instance.lines.Length -1;
				//Anim
				SetPosition();
			break;
		}

	}
}


//colisiones
