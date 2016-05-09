using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
  public FPSWalker walker = null;
  public float deathDelay = 1.0f;
  private float deathStart = 0.0f;
  public float previousSpeed = 0.0f;
  public bool delaying = false;

  public int deathCount = 0;
  public Vector3 startPosition = new Vector3(0, 1, 0);
  private GUIStyle style = new GUIStyle();

  void Start ()
  {
    style.alignment = TextAnchor.MiddleCenter;
    if(walker == null) {
      Debug.Log("Error.. Death Script Needs FPS Walker");
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
    deathCount++;
    transform.position = startPosition;
    Debug.Log("Death Count: " + deathCount);
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
  }

  void OnGUI ()
  {
    string death_string = deathCount.ToString() + " death";
    if (deathCount != 1) {
      death_string += "s";
    }
    GUI.Box(new Rect(5, Screen.height - 30,80,25), death_string, style);
  }
}
