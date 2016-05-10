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
	public override void Mutate(Constraints constraints) {
		// to be implemented
	}

	public override void PostCrossoverMutate(Constraints constraints) {
		// to be implemented
	}

	public override void Crossover(Constraints constraints,Trajectory other) {
		// to be implemented
	}

	public override void CreateRandomSelf(Constraints constraints) {
		// to be implemented
	}
}
