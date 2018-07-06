//Generacion de mundo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject[] Swamp;
    public GameObject[] Castle;
    public GameObject[] Boss;
    public static Generator instance;

    public int contador;

    //procedural
    public GameObject firstPos;
    public GameObject[] tiles;
    public int[] order;
    public string world;


    public Transform startingPos;
    //
    ModSwipe ms = new ModSwipe();

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        contador = 0;
        world = "Swamp";
        startingPos.position = firstPos.transform.position;
        //GameObject tile = Instantiate(Template[Random.Range(0,Template.Length)], firstPos.transform.position, Quaternion.identity);
        GameObject tile = Instantiate(Swamp[Random.Range(0, Swamp.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
        startingPos = tile.transform.Find("Helper");


        string[] numbers = "1-2-3-4-5-6-7-8-9-0".Split('-');
        Debug.Log(numbers[5]);
        //InvokeRepeating("Spawn",1.25f,1.25f);

    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 10)
        {
            if (world == "Swamp")
            {
                world = "Castle";
                contador = 0;
            }else if (world == "Castle")
            { 
            world = "Boss";
            contador = 0;
            }
        }
        
    }

    public void Spawn()
    {
        switch (world)
        {
            case "Swamp":
                GameObject tile = Instantiate(Swamp[Random.Range(0, Swamp.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
                startingPos = tile.transform.Find("Helper");
                break;

            case "Castle":
                GameObject tile2 = Instantiate(Castle[Random.Range(0, Castle.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
                startingPos = tile2.transform.Find("Helper");
                break;

            case "Boss":
                break;
        }
        /*if (ms.contador <= 10)
        {
            GameObject tile = Instantiate(Swamp[Random.Range(0, Swamp.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
            startingPos = tile.transform.Find("Helper");
            ms.contador = 0;
        }
        else if (ms.contador <= 11)
        {
            GameObject tile = Instantiate(Castle[Random.Range(0, Castle.Length)], startingPos.position, new Quaternion(0, 0.5f, 0, 0));
            startingPos = tile.transform.Find("Helper");
        }
		/  /Instantiate(Template[Random.Range(0,8)], transform.position, transform.rotation);
	}*/
    }
}
