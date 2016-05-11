using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
  public PGSystem pgRef = null;
  public FPSWalker walker = null;
  public BossController bossController = null;
  public WallController wallController = null;
  public DeathPersist deathPersist = null;
  public float deathDelay = 1.0f;
  private float deathStart = 0.0f;
  public float previousSpeed = 0.0f;
  public bool delaying = false;

  public int deathCount = 0;
  public Vector3 startPositionOne = new Vector3(0, 1, -44);
  public Vector3 startPositionTwo = new Vector3(0, 1, 44);
  public Vector3 startPositionBoss;
  public GUIStyle style = new GUIStyle();

  void Start ()
  {
    style.alignment = TextAnchor.MiddleCenter;
    if(walker == null) {
      Debug.Log("Error.. Death Script Needs FPS Walker");
    }
    if(pgRef == null) {
      Debug.Log("Error.. Death Script Needs Ref to PGSystem");
    }
    GameObject deathPersistObj = GameObject.Find("DeathPersist");
    if(deathPersistObj != null) {
      deathPersist = deathPersistObj.GetComponent<DeathPersist>();
      if(deathPersist == null) {
        Debug.Log("Error.. Death Persist Object Exists but Its Script is Null");
      }
    } else {
      Debug.Log("Error.. Death Persist Object Can Not Be Found");
    }
  }

	// Update is called once per frame
	void Update () {
    if(delaying) {
      if(Time.time - deathStart > deathDelay) {
        delaying = false;
        walker.speed = previousSpeed;
      }
    }
    if (transform.position.y < -50)
    {
      Die();
    }
  }

  void OnTriggerEnter (Collider other)
  {
    if (other.gameObject.tag.Contains("Death"))
    {
      Die();
    }
  }

  void Die()
  {
	pgRef.PlayerDied();
	if(wallController != null) {
	  wallController.Reset();
	}
	deathCount++;
	if (pgRef.isBoss) {
		transform.position = startPositionBoss;

	}
	else if(pgRef.levelNum % 2 == 0) {
	  transform.position = startPositionOne;
	} else {
	  transform.position = startPositionTwo;
	}
	// pause movement
	if(!delaying) {
	  delaying = true;
	  previousSpeed = walker.speed;
	  walker.speed = 0.0f;
	  deathStart = Time.time;
	}

	GameObject[] bullets = GameObject.FindGameObjectsWithTag("bulletDeath");
	foreach (GameObject bullet in bullets) {
		Destroy (bullet);
	}
	GameObject[] chasers = GameObject.FindGameObjectsWithTag("chaserDeath");
	foreach (GameObject chaser in chasers) {
		if ((chaser.GetComponent<ChaserController> ())) {
			(chaser.GetComponent<ChaserController> ()).Reset ();
		}
	}

	if(pgRef.isBoss){
    deathPersist.bossDeaths++;
		pgRef.resetGA();
    	bossController.ResetBoss();
		walker.ResetMouseLook ();
    if(deathCount != 0 && deathCount % 2 == 0) {
      if(bossController.spawnNums != 1) {
        bossController.spawnNums--;
      }
    }
	} else {
    deathPersist.pgDeaths++;
  }
  }

  void OnGUI ()
  {
    string death_string = deathCount.ToString() + " death";
    if (deathCount != 1) {
      death_string += "s";
    }
    GUI.Box(new Rect(5, Screen.height - 30,80,25), death_string, style);

	string level_string = "level " + (pgRef.levelNum+1).ToString();
	if (pgRef.levelNum >= 10)
		level_string = "final boss";
	GUI.Box(new Rect(Screen.width - 75, Screen.height - 30,80,25), level_string, style);
  }
}
