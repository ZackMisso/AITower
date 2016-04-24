using UnityEngine;
using System;
using System.Collections;

// This class is an abstract version of what a trajectory for a bullet should be

public abstract class Trajectory : MonoBehaviour {
	// still figuring out how this will work
	public Vector3 lineOfSight = new Vector3();
	public Vector3 initialPosition = new Vector3();
	public bool followLineOfSight = false;
	protected float startTime;
	protected float lastUpdateTime;
	public float frequency; // time to move one unit

	public void FixedUpdate() {
		//Debug.Log("ASFASDF");
		//FollowTrajectory();
	}

	public void BeginTrajectory(Transform currentTransform) {
		startTime = Time.time;
		lastUpdateTime = Time.time;
		initialPosition = currentTransform.position;
	}

	public abstract void FollowTrajectory(Transform currentTransform);
}
