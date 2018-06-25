using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;
	
	public Transform[] lines;
	public float moduleLength;

	private List<Level> levels = new List<Level>();
	private List<ModuleHolder> modules = new List<ModuleHolder>();
	private Queue<GameObject> inGameModules = new Queue<GameObject>();

	private Vector3 startingPoint;
	private Vector3 endPoint;

	private int currentLevel;
	private bool endLevel;

	void Start () {
		if (instance == null) instance = this;
		CreateLevels();
		startingPoint = PlayerManager.playerRef.position;
		endPoint = startingPoint;
		LoadLevel();
	}

	void CreateLevels () {
		Level temp = new Level (1, "Nivel 1", 3, 10, Level.Zone.Swamp, Level.Zone.Swamp);
		levels.Add(temp);
		temp = new Level (2, "Nivel 2", 3, 10, Level.Zone.Swamp, Level.Zone.Castle);
		levels.Add(temp);
		temp = new Level (3, "Nivel 3", 3, 10, Level.Zone.Castle, Level.Zone.None);
		levels.Add(temp);
	}

	public void SaveModule (ModuleHolder module) {
		modules.Add(module);
	}

	void LoadLevel () {
		//Llamar transición
		int onQueue = inGameModules.Count;
		for (int i = 0; i < onQueue; i++){
			inGameModules.Dequeue();
		}
		//Modificar spawn para que coincida con las zonas
		SpawnModule(modules[0]);
		SpawnModule(modules[0]);
		SpawnModule(modules[0]);
	}

	void SpawnModule (ModuleHolder targetModule) {
		if (targetModule == null) {
			int r;
			targetModule = new ModuleHolder();

			while (targetModule.module.zone != levels[currentLevel].zone){
				r = Random.Range(0, modules.Count);
				targetModule = modules[r];
			}

		}
		GameObject temp = Instantiate(targetModule, endPoint, PlayerManager.playerRef.rotation).gameObject;
		inGameModules.Enqueue(temp);
		endPoint.z += moduleLength;
		levels[currentLevel].AddToCounter();
		endLevel = levels[currentLevel].EndLevel();
	}

	public void EndModule () {
		if (endLevel){
			ChangeLevel();
			return;
		}
		SpawnModule(null);
		Destroy(inGameModules.Dequeue());
	}

	public void ChangeLevel (){
		Level.Zone nextZone = levels[currentLevel].nextZone;
		if (nextZone == Level.Zone.None){
			Debug.Log("Victoria");
		} else {
			currentLevel++;
			if (currentLevel >= levels.Count){
				currentLevel = 0;
				while (levels[currentLevel].zone != nextZone) {
					currentLevel = Random.Range (0, levels.Count);
				}
			}
		}
		endLevel = false;
		LoadLevel();
	}
}

// puntuacion y velocidad