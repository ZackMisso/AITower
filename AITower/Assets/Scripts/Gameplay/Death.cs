using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public int deathCount = 0;
    public Vector3 startPosition = new Vector3(0, 1, 0);
    private GUIStyle style = new GUIStyle();

    void Start ()
    {
        style.alignment = TextAnchor.MiddleCenter;
    }

	// Update is called once per frame
	void Update () {
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

		GameObject[] bullets = GameObject.FindGameObjectsWithTag("bulletDeath");
		foreach (GameObject bullet in bullets) {
			Destroy (bullet);
		}
		GameObject[] chasers = GameObject.FindGameObjectsWithTag("chaserDeath");
		foreach (GameObject chaser in chasers) {
			(chaser.GetComponent<ChaserController>()).Reset();
		}
    }

    void OnGUI ()
    {
        string death_string = deathCount.ToString() + " death";
        if (deathCount != 1)
            death_string += "s";

        GUI.Box(new Rect(5, Screen.height - 30,80,25), death_string, style);
    }
}
