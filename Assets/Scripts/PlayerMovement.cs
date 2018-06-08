//script de deteccion de objetos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// movimiento del jugador 
    // movimiento de derecha a izquierda
	void Update () {

		Target.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);

		transform.position = Vector3.MoveTowards(transform.position,Target.position, 10 * Time.deltaTime);
		
	}

    // interaccion con los bloques
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Plantilla")
		{
			//Generator.instance.Spawn();
			Destroy(other.gameObject,1.5f);	
		}
		
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Cobweb")
		{
			GameController.instance.Speed = 0;
			StopCoroutine("Restart");
			StartCoroutine("Restart");
		}

		if(other.gameObject.tag == "Coin")
		{
			Destroy(other.gameObject);
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Hazard")
		{
			GameController.instance.InvokeRepeating("DeAccel",0.1f,2);
			StopCoroutine("Restart");
			StartCoroutine("Restart");			
		}
	}

    // reinicio de nivel
	private IEnumerator Restart()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(0);
	} 
}
