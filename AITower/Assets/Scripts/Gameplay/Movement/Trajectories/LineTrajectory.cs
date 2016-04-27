using UnityEngine;
using System.Collections;

public class LineTrajectory : Trajectory {
	void Update() {
		lineOfSight = transform.forward;
	}

	public override void FollowTrajectory(Transform currentTransform,float time) {
    float newX = currentTransform.position.x + lineOfSight.x * speed;
    float newY = currentTransform.position.y + lineOfSight.y * speed;
    float newZ = currentTransform.position.z + lineOfSight.z * speed;
    currentTransform.position = new Vector3(newX,newY,newZ);
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
