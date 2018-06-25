using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleHolder : MonoBehaviour {

	public int id;
	public string name_;
	public Module.ModuleType moduleType;
	public Level.Zone zone;

	public Module module;
	
	void Awake () {
		module = new Module(id, name_, moduleType, zone);
		LevelManager.instance.SaveModule(this);
	}

	void Update() {
		//Mover módulos
	}
}
