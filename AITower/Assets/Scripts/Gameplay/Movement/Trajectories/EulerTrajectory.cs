using UnityEngine;
using System.Collections;

public class EulerTrajectory : Trajectory {
	public float acceleration = -0.1f;
	public float startingYVelocity = 0.1f;

	void Update () {
		if(!isBoss) {
			lineOfSight = transform.forward;
		}
	}

	public override void FollowTrajectory(Transform currentTransform,float time) {
		float newX = currentTransform.position.x + lineOfSight.x * speed;
    float newY = currentTransform.position.y + (startingYVelocity + time*acceleration);
    float newZ = currentTransform.position.z + lineOfSight.z * speed;
		currentTransform.position = new Vector3(newX,newY,newZ);
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
