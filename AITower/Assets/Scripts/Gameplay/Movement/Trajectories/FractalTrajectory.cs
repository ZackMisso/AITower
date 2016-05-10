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
		float losX = lineOfSight.x + (Random.value - 0.5f) * 0.2f;
		float losY = lineOfSight.x + (Random.value - 0.5f) * 0.2f;
		float losZ = lineOfSight.x + (Random.value - 0.5f) * 0.2f;
		lineOfSight.x = losX;
		lineOfSight.y = losY;
		lineOfSight.z = losZ;
		lineOfSight.Normalize();
		speed += (Random.value - 0.5f) * 0.2f;
		if(speed > constraints.TrajectoryMaxSpeed) {
			speed = constraints.TrajectoryMaxSpeed;
		}
		if(speed < constraints.TrajectoryMinSpeed) {
			speed = constraints.TrajectoryMinSpeed;
		}
		// trajectory specific mutation
		// to be implemented
	}

	public override void PostCrossoverMutate(Constraints constraints) {
		// to be implemented
	}

	public override void Crossover(Constraints constraints,Trajectory other) {
		int num = Random.Range(0,6);
		Vector3 newLos = new Vector3();
		switch(num) {
			case 0: {
				newLos.x = other.lineOfSight.x;
				newLos.y = lineOfSight.y;
				newLos.z = lineOfSight.z;
				break;
			} case 1: {
				newLos.x = lineOfSight.x;
				newLos.y = other.lineOfSight.y;
				newLos.z = lineOfSight.z;
				break;
			} case 2: {
				newLos.x = lineOfSight.x;
				newLos.y = lineOfSight.y;
				newLos.z = other.lineOfSight.z;
				break;
			} case 3: {
				newLos.x = other.lineOfSight.x;
				newLos.y = other.lineOfSight.y;
				newLos.z = lineOfSight.z;
				break;
			} case 4: {
				newLos.x = other.lineOfSight.x;
				newLos.y = lineOfSight.y;
				newLos.z = other.lineOfSight.z;
				break;
			} case 5: {
				newLos.x = lineOfSight.x;
				newLos.y = other.lineOfSight.y;
				newLos.z = other.lineOfSight.z;
				break;
			}
			default: {
				// does nothing
				break;
			}
		}
		newLos.Normalize();
		lineOfSight = newLos;
		speed += Random.value * (speed - other.speed);
	}

	public override void CreateRandomSelf(Constraints constraints) {
		// to be implemented
	}
}
