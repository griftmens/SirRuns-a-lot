using System.Collections;
using System.Collections.Generic;

public class Module : Entity {

	public enum ModuleType {
		Clear,
		SingleObstacle,
		DoubleObstacle,
		Goal,
	}

	public ModuleType moduleType;
	public Level.Zone zone;

	public Module () {
		id = 0;
		name = "";
		moduleType = ModuleType.Clear;
		zone = Level.Zone.None;
	}

	public Module (int id, string name, ModuleType moduleType, Level.Zone zone) {
		this.id = id;
		this.name = name;
		this.moduleType = moduleType;
		this.zone = zone;
	}	
}
