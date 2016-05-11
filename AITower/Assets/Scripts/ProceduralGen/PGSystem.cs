using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PGSystem : MonoBehaviour {
	public GA gaRef;
	public int levelDeaths;
	public int totalDeaths;
	public int numberGunShots;
	public int levelNum;
	public int prevNumberOfTurrets;
	public bool isBoss = false;
    private GameObject basicSquare;
    private GameObject triShooter;
    private GameObject chaser4;
    private GameObject sin4;
    private GameObject chaser;
    private GameObject lineShooter;
    private GameObject desync;
    private GameObject sinLava;
    private GameObject sinEuler;
    
    private GameObject[,] grid;
    private int gridSize = 10;


    public PGSystem() {
		levelDeaths = 0;
		totalDeaths = 0;
		numberGunShots = 0;
		//levelNum=0;
		prevNumberOfTurrets=0;
        grid = new GameObject[gridSize, gridSize];
    }
    
	public void GenerateLevel() {
		if(!isBoss) {
        Debug.Log("Generating Level " + levelNum);
            
        if(!basicSquare)
                basicSquare = Resources.Load("GridPatterns/BasicSquare") as GameObject;
        if(!triShooter)
                triShooter = Resources.Load("GridPatterns/TriShooter") as GameObject;
        if(!chaser4)
                chaser4 = Resources.Load("GridPatterns/4ChaserShooter") as GameObject;
        if(!sin4)
                sin4 = Resources.Load("GridPatterns/4SineShooter") as GameObject;
        if(!chaser)
                chaser = Resources.Load("GridPatterns/BasicChaserShooter") as GameObject;
        if(!lineShooter)
                lineShooter = Resources.Load("GridPatterns/LineShooter") as GameObject;
        if(!desync)
                desync = Resources.Load("GridPatterns/DesyncShooter") as GameObject;
        if(!sinEuler)
                sinEuler = Resources.Load("GridPatterns/Sine2EulerShooter") as GameObject;
        if(!sinLava)
                sinLava = Resources.Load("GridPatterns/SineLavaShooter") as GameObject;

        for (int i = 0; i < gridSize; ++i)
        {
            for(int j = 1; j < gridSize - 1; ++j)
            {
                if (grid[i, j])
                {
                    Destroy(grid[i, j]);
                    grid[i, j] = null;
                }
            }
        }

        int numBasicSquare = CalculateBS();
        int numTriShooter = CalculateTS();
        int numChaser4 = CalculateC4();
        int numSin4 = CalculateS4();
        int numChaser = CalculateChaser();
        int numLine = CalculateLine();
        int numDesync = CalculateDesync();
        int numSEul = CalculateSEul();
        int numSLava = CalculateSLava();
        
        Place(basicSquare, numBasicSquare);
        Place(triShooter, numTriShooter);
        Place(chaser4, numChaser4);
        Place(sin4, numSin4);
        Place(chaser, numChaser);
        Place(lineShooter, numLine);
        Place(desync, numDesync);
        Place(sinEuler, numSEul);
        Place(sinLava, numSLava);

        for(int i = 0; i < 10; ++i)
        {
            for (int j = 1; j < 10; ++j)
            {
                if (grid[i, j])
                {
                    grid[i, j].transform.position = new Vector3(10 * (i - (gridSize / 2)) + 5, 0.0f, 10 * (j - (gridSize / 2)) + 5);
                    //TODO - fix orientation
                    grid[i, j].transform.rotation = Quaternion.AngleAxis((Mathf.Floor(Random.Range(0.0f, 100.0f)) % 4) * 90, Vector3.up);
                }
            }
        }

        }
        else {
			gaRef.StartGA();
		}
	}

	public void PlayerDied() {
		levelDeaths++;
		totalDeaths++;
        if(levelDeaths > 5 && !isBoss)
        {
            levelDeaths = 0;
            GenerateLevel();
        }
	}

	public void resetGA(){
		gaRef.PlayerDied ();
	}

	public void BeatLevel() {
		levelDeaths = 0;
		levelNum++;

		if (levelNum >= 8) {
			isBoss = true;
			SceneManager.LoadScene ("BossTest");
		} else {
			GenerateLevel ();
		}
	}

    private void Place(GameObject obj, int num)
    {
        for (int i = 0; i < num; ++i)
        {
            int xc = 0;
            int yc = 0;
            do
            {
                xc = (int)Mathf.Floor(Random.Range(0.0f, 10.0f));
                yc = (int)Mathf.Floor(Random.Range(1.0f, 9.0f));
            } while (!(xc > 0 && xc < 10 && yc > 1 && yc < 9 && !((yc == 1 || yc == 8) && (xc == 4 || xc == 5))));

            if(grid[xc,yc])
            {
                Destroy(grid[xc, yc]);
            }
            grid[xc, yc] = Instantiate(obj) as GameObject;
        }
    }


    private int CalculateBS()
    {
        return Mathf.Max(6 - levelNum, 0);
    }

    private int CalculateTS()
    {
        if (levelNum == 0)
            return 0;
        return Mathf.Max(4 + (levelNum / 2) - (totalDeaths / 2), 1);
    }

    private int CalculateC4()
    {
        if (levelNum < 2)
            return 0;
        return Mathf.Max(2 + (2*levelNum) - (totalDeaths), 1);
    }

    private int CalculateS4()
    {
        if (levelNum < 3)
            return 0;
        return Mathf.Max((2*levelNum) - (totalDeaths), 1);
    }

    private int CalculateChaser()
    {
        if (levelNum < 4)
            return 0;
        return Mathf.Max(2 + (levelNum) - (totalDeaths/2), 1);
    }

    private int CalculateLine()
    {
        if (levelNum < 5)
            return 0;
        return Mathf.Max((4 * levelNum) - (3*totalDeaths), 1);
    }

    private int CalculateDesync()
    {
        if (levelNum < 5)
            return 0;
        return Mathf.Max(2 + (levelNum) - (totalDeaths), 0);
    }

    private int CalculateSEul()
    {
        if (levelNum < 5)
            return 0;
        return Mathf.Max((2 * levelNum) - (2 * totalDeaths), 0);
    }


    private int CalculateSLava()
    {
        if (levelNum < 6)
            return 0;
        return Mathf.Max(6 + (2*levelNum) - (2*totalDeaths), 1);
    }

}
