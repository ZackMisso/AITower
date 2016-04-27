using UnityEngine;
using System.Collections;

public class FractalTrajectory : Trajectory {
	public Vector3 currentDir;
	public float angle = 30.0f;

	void Start() {
		currentDir = transform.forward;
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
