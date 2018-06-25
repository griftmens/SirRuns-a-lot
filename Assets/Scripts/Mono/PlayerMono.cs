using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMono : MonoBehaviour {

	public PlayerController playerController;
	//public PlayerView playerView;
	//public PlayerModel playerModel;
	public Transform startingPos;
	public Transform jumpPos;

	private IEnumerator jump;
	private bool jumping;
	// Use this for initialization
	void Start () {
		startingPos = transform;
		playerController = new PlayerController();
		//playerView = new PlayerView();
		//playerModel = new PlayerModel();
	}
	
	// Update is called once per frame
	void Update () {
		playerController.Update();
		//playerModel.Update();
		//playerView.Update();
	}

	public void Receptor (string dir) {

		switch(dir) {
			case "Arriba":
			transform.position = jumpPos.position;
			if (jump == null) jump = Jump();	
			Helper.instance.StopCoroutine(jump);
			Helper.instance.StartCoroutine(jump);
			break;

			case "Abajo":
			break;

			case "Izquierda":
			break;

			case "Derecha":
			break;

			default:
			break;
		}

	}

	private IEnumerator Jump() {
		if(jumping == false){
			yield return null;
		}

		yield return new WaitForSeconds(0.4f);
		
		transform.position = new Vector3(startingPos.position.x,1.5f,startingPos.position.z);
		jumping = false;
	}
}
