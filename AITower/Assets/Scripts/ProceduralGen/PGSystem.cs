using UnityEngine;
using System.Collections;

public class PGSystem : MonoBehaviour {
	////////////////////// GLOBAL FUNCTIONS ///////////////////////////

	static PGSystem instance;

	public static PGSystem GetInstance() {
		return instance;
	}

	public static void Initialize() {
		instance = new PGSystem();
	}

	///////////////////////////////////////////////////////////////////

	private int levelDeaths;
	private int totalDeaths;
	private int numberGunShots;
	private int levelNum;
	private int prevNumberOfTurrets;

	public PGSystem() {
		levelDeaths = 0;
		totalDeaths = 0;
		numberGunShots = 0;
		levelNum=0;
		prevNumberOfTurrets=0;
	}

	// level bounds 37 to -37
	public void GenerateLevel() {
		levelNum++;
		Debug.Log("Generating Level");
		int turrets = calculateNumberOfNewTurrets();
		for(int i=0;i<turrets;i++) {
			Debug.Log("Generating Turret");
			float xpos = Random.value - 0.5f;
			float zpos = Random.value - 0.5f;
			float angle = Random.value * 360;
			xpos *= 37;
			zpos *= 37;
			GameObject bullet = (GameObject)Instantiate(Resources.Load("Turret"));
			bullet.transform.position = new Vector3(xpos,1.0f,zpos);
			bullet.transform.rotation = Quaternion.AngleAxis(angle,Vector3.up);
		}
		// to be impelemented
	}

	public int calculateNumberOfNewTurrets() {
		// to be implemented
		return 8;
	}
}
