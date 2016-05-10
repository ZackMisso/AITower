using UnityEngine;
using System.Collections;

public class PGSystem : MonoBehaviour {
	public GA gaRef;
	public int levelDeaths;
	public int totalDeaths;
	public int numberGunShots;
	public int levelNum;
	public int prevNumberOfTurrets;
	public bool isBoss = false;

	public PGSystem() {
		levelDeaths = 0;
		totalDeaths = 0;
		numberGunShots = 0;
		levelNum=0;
		prevNumberOfTurrets=0;
	}

	// level bounds 37 to -37
	public void GenerateLevel() {
		if(!isBoss) {
        Debug.Log("Generating Level");

        int gridSize = 10;
        GameObject[,] grid = new GameObject[gridSize,gridSize];
        GameObject basicSquare = Resources.Load("GridPatterns/BasicSquare") as GameObject;
        GameObject triShooter = Resources.Load("GridPatterns/TriShooter") as GameObject;

        for (int i = 0; i < gridSize; ++i)
        {
            for(int j = 1; j < gridSize - 1; ++j)
            {

                bool place = false;
                if (Random.Range(0.0f,100.0f) < CalculateBSChance())
                {
                    grid[i, j] = Instantiate(basicSquare) as GameObject;
                    place = true;
                }

                else if (Random.Range(0.0f,100.0f) < CalculateTSChance())
                {
                    grid[i, j] = Instantiate(triShooter) as GameObject;
                    place = true;
                }
                if (place)
                {
                    grid[i, j].transform.position = new Vector3(10 * (i - (gridSize / 2)) + 5, 0.0f, 10 * (j - (gridSize / 2)) + 5);
                    grid[i, j].transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }
        }
			} else {
				gaRef.StartGA();
			}
	}

	public void PlayerDied() {
		levelDeaths++;
		totalDeaths++;
	}

	public void BeatLevel() {
		levelDeaths = 0;
		levelNum++;
		GenerateLevel();
	}

    private float CalculateBSChance()
    {
        if (levelNum == 0)
            return 10.0f;
        else
            return Mathf.Max(1.0f + (4.0f - totalDeaths), 0.0f);
    }

    private float CalculateTSChance()
    {
        return levelNum - Mathf.Min(totalDeaths / 3.0f, 10.0f);
    }

	public int CalculateNumberOfNewTurrets() {
		// to be implemented
		return 8;
	}
}
