using UnityEngine;
using System;
using System.Collections;

// This class is an abstract version of what a trajectory for a bullet should be

public abstract class Trajectory : MonoBehaviour {
	// still figuring out how this will work
	public Vector3 lineOfSight = new Vector3();
	public Vector3 initialPosition = new Vector3();
	public bool followLineOfSight = false;
	public bool isBoss = false;
	public int type; // used for boss fight 1-line 2-fractal 3-sine 4-euler
	//protected float startTime;
	//protected float lastUpdateTime;
	public float speed; // time to move one unit

	//public void FixedUpdate() {
		//Debug.Log("ASFASDF");
		//FollowTrajectory();
	//}

	//public void BeginTrajectory(Transform currentTransform) {
	//	startTime = Time.time;
	//	lastUpdateTime = Time.time;
	//	initialPosition = currentTransform.position;
	//}

	public abstract void FollowTrajectory(Transform currentTransform,float time);
	// GA Methods
	public abstract void Mutate(Constraints constraints);
	public abstract void PostCrossoverMutate(Constraints constraints);
	public abstract void Crossover(Constraints constraints,Trajectory other);
	public abstract void CreateRandomSelf(Constraints constraints);
}
