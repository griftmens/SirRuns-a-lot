using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;
	
	public Transform[] lines;

	private List<Level> levels = new List<Level>();
	public int currentLevel;

	void Start () {
		if (instance == null) instance = this;
		CreateLevels();
	}

	void CreateLevels () {
		Level temp = new Level (1, "Nivel 1", 3, 10, Level.Zone.Swamp, Level.Zone.Swamp);
		levels.Add(temp);
		temp = new Level (2, "Nivel 2", 3, 10, Level.Zone.Swamp, Level.Zone.Castle);
		levels.Add(temp);
		temp = new Level (3, "Nivel 3", 3, 10, Level.Zone.Castle, Level.Zone.None);
		levels.Add(temp);
	}

	void LoadLevel () {

	}

	void EndModule () {
		levels[currentLevel].AddToCounter();
	}
}
