using System.Collections;
using System.Collections.Generic;

public class Level : Entity {

	public int lineNumber;
	private int moduleCounter;
	public int maxModules;

	public enum Zone {
		Swamp,
		Castle,
		None,
	}
	public Zone zone;
	public Zone nextZone;

	public Level () {
		id = 0;
		name = "";
		lineNumber = 1;
		moduleCounter = 0;
		maxModules = 0;
		zone = Zone.None;
		nextZone = Zone.None;
	}
	
	public Level (int id, string name, int lineNumber, int maxModules, Zone zone, Zone nextZone) {
		this.id = id;
		this.name = name;
		this.lineNumber = lineNumber;
		moduleCounter = 0;
		this.maxModules = maxModules;
		this.zone = zone;
		this.nextZone = nextZone;
	}

	public void AddToCounter () {
		moduleCounter++;
	}

	public bool EndLevel () {
		if (moduleCounter >= maxModules) return true;
		return false;
	}
}
