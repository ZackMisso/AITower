using UnityEngine;
using System.Collections;

public class FractalTrajectory : Trajectory {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void FollowTrajectory(Transform currentTransform,float time) {
		// to be implemented
	}

	// GA Methods
	public override Trajectory Mutate() {
		// to be implemented
		return null;
	}

	public override Trajectory Crossover(Trajectory other) {
		// to be implemented
		return null;
	}

	public override Trajectory CreateRandomSelf() {
		// to be implemented
		return null;
	}
}
