using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public LineTrajectory lineTraj;
	public float reloadTime = 0;

	float timeSinceLastBullet;

	// is just transform.position
	// ^^ But we can have turrets of different sizes. Therefore we need an offset
	// to where the cannon is for the turret
	//public Vector3 position;

	//is just transform.right
	//public Vector3 lookDirection;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//transform.Rotate(Vector3.up, Time.deltaTime*90);

		timeSinceLastBullet += Time.deltaTime;
		if (timeSinceLastBullet >= reloadTime) {
			LineTrajectory lt = (LineTrajectory)Instantiate(lineTraj, transform.position, Quaternion.identity);
			lt.lineOfSight = transform.right;
			lt.initialPosition = transform.position;

			timeSinceLastBullet = 0;
		}
	}
}
