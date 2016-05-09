using UnityEngine;
using System.Collections;

public class PGSystem : MonoBehaviour {
	public int levelDeaths;
	public int totalDeaths;
	public int numberGunShots;
	public int levelNum;
	public int prevNumberOfTurrets;

	public PGSystem() {
		levelDeaths = 0;
		totalDeaths = 0;
		numberGunShots = 0;
		levelNum=0;
		prevNumberOfTurrets=0;
	}

	// level bounds 37 to -37
	public void GenerateLevel() {
        Debug.Log("Generating Level");
        levelNum++;

        int gridSize = 10;
        GameObject[,] grid = new GameObject[gridSize,gridSize];
				Debug.Log("Before Load");
        GameObject basicSquare = Resources.Load("GridPatterns/BasicSquare") as GameObject;
				Debug.Log("After Load");
        for(int i = 1; i < gridSize - 1; ++i)
        {
            for(int j = 1; j < gridSize - 1; ++j)
            {
                if (i + j % 4 == 0)
                {
                    Debug.Log("Making + " + i + "," + j);
                    grid[i, j] = Instantiate(basicSquare) as GameObject;
                    grid[i, j].transform.position = new Vector3(10 * (i - (gridSize / 2)) + 5, 1.0f, 10 * (j - (gridSize / 2)) + 5);
                    grid[i, j].transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }
        }

		//levelNum++;
		//Debug.Log("Generating Level");
		//int turrets = CalculateNumberOfNewTurrets();
		//for(int i=0;i<0;i++) {
		//	Debug.Log("Generating Turret");
		//	float xpos = Random.value - 0.5f;
		//	float zpos = Random.value - 0.5f;
		//	float angle = Random.value * 360;
		//	xpos *= 37;
		//	zpos *= 37;
		//	GameObject bullet = (GameObject)Instantiate(Resources.Load("Turret"));
		//	bullet.transform.position = new Vector3(xpos,1.0f,zpos);
		//	bullet.transform.rotation = Quaternion.AngleAxis(angle,Vector3.up);
		//}
		// to be impelemented
	}

	public void PlayerDied() {
		levelDeaths++;
		totalDeaths++;
	}

	public void BeatLevel() {
		levelDeaths = 0;
		levelNum = 1;
		GenerateLevel();
	}

	public int CalculateNumberOfNewTurrets() {
		// to be implemented
		return 8;
	}
}
