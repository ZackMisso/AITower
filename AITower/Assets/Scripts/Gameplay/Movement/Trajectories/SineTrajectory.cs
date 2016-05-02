using UnityEngine;
using System.Collections;

public class SineTrajectory : Trajectory {
	public Vector3 sineMap = new Vector3(0.0f,1.0f,0.0f);
	public float amplitude = 1.0f;
	public float crest = 1.0f;

	void Update() {
		lineOfSight = transform.forward;
		initialPosition = transform.position + 2.0f*transform.forward;
	}

	public override void FollowTrajectory(Transform currentTransform,float time) {
		float newX = initialPosition.x + lineOfSight.x * speed * time;
		float newY = initialPosition.y + lineOfSight.y * speed * time;
		float newZ = initialPosition.z + lineOfSight.z * speed * time;
    float dX = sineMap.x * Mathf.Sin(time/crest) * amplitude;
    float dY = sineMap.y * Mathf.Sin(time/crest) * amplitude;
    float dZ = sineMap.z * Mathf.Sin(time/crest) * amplitude;
    currentTransform.position = new Vector3(newX+dX,newY+dY,newZ+dZ);
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
