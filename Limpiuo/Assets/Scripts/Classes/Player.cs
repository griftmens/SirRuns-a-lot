using System.Collections;
using System.Collections.Generic;

public class Player : Entity {

	public int currentLine;
	public float speed;
	public float jumpForce;
	public bool jumping;
	public bool sliding;

	public Player () {
		id = 0;
		name = "";
		speed = 1f;
		jumpForce = 5f;
		currentLine = 1;
		jumping = false;
		sliding = false;
	}

	public Player (int id, string name, float speed, float jumpForce){
		this.id = id;
		this.name = name;
		this.speed = speed;
		this.jumpForce = jumpForce;
		currentLine = 1;
		jumping = false;
		sliding = false;
	}

}
