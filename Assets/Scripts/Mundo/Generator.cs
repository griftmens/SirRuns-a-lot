//Generacion de mundo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject[] Template;
	public static Generator instance;

	//procedural
	public GameObject[] tiles;
	public GameObject firstPos;
    public int[] order;


    public Transform startingPos;
	//

	
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

			startingPos.position = firstPos.transform.position;
            //GameObject tile = Instantiate(Template[Random.Range(0,Template.Length)], firstPos.transform.position, Quaternion.identity);
			GameObject tile = Instantiate(Template[Random.Range(0,Template.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
			startingPos = tile.transform.Find("Helper");


        string[] numbers = "1-2-3-4-5-6-7-8-9-0".Split('-');
        Debug.Log(numbers[5]);
		//InvokeRepeating("Spawn",1.25f,1.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		GameObject tile = Instantiate(Template[Random.Range(0,Template.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
        startingPos = tile.transform.Find("Helper");
		//Instantiate(Template[Random.Range(0,8)], transform.position, transform.rotation);
	}
}
