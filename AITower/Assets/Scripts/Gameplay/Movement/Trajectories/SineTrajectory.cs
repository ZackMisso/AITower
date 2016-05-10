using UnityEngine;
using System.Collections;

public class SineTrajectory : Trajectory {
	public Vector3 sineMap = new Vector3(0.0f,1.0f,0.0f);
	public float amplitude = 1.0f;
	public float crest = 1.0f;

	void Update() {
		if(!isBoss) {
			lineOfSight = transform.forward;
			initialPosition = transform.position + 2.0f*transform.forward;
		}
	}

	public override void FollowTrajectory(Transform currentTransform,float time) {
		float newX = initialPosition.x + lineOfSight.x * speed * time;
		float newY = initialPosition.y + lineOfSight.y * speed * time;
		float newZ = initialPosition.z + lineOfSight.z * speed * time;
		if(crest == 0.0f) {
			Debug.Log("Zero Error");
		}
    float dX = sineMap.x * Mathf.Sin(time/crest) * amplitude;
    float dY = sineMap.y * Mathf.Sin(time/crest) * amplitude;
    float dZ = sineMap.z * Mathf.Sin(time/crest) * amplitude;
    currentTransform.position = new Vector3(newX+dX,newY+dY,newZ+dZ);
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
		amplitude += (Random.value - 0.5f) * 0.2f * (constraints.SineTrajectoryMaxAmplitude-constraints.SineTrajectoryMinAmplitude);
		crest += (Random.value - 0.5f) * 0.2f * (constraints.SineTrajectoryMaxCrest-constraints.SineTrajectoryMinCrest);
		if(amplitude > constraints.SineTrajectoryMaxAmplitude) {
			amplitude = constraints.SineTrajectoryMaxAmplitude;
		}
		if(amplitude < constraints.SineTrajectoryMinAmplitude) {
			amplitude = constraints.SineTrajectoryMinAmplitude;
		}
		if(crest > constraints.SineTrajectoryMaxCrest) {
			crest = constraints.SineTrajectoryMaxCrest;
		}
		if(crest < constraints.SineTrajectoryMinCrest) {
			crest = constraints.SineTrajectoryMinCrest;
		}
	}

	public override void PostCrossoverMutate(Constraints constraints) {
		amplitude += (Random.value - 0.5f) * 0.2f * (constraints.SineTrajectoryMaxAmplitude-constraints.SineTrajectoryMinAmplitude);
		crest += (Random.value - 0.5f) * 0.2f * (constraints.SineTrajectoryMaxCrest-constraints.SineTrajectoryMinCrest);
		if(amplitude > constraints.SineTrajectoryMaxAmplitude) {
			amplitude = constraints.SineTrajectoryMaxAmplitude;
		}
		if(amplitude < constraints.SineTrajectoryMinAmplitude) {
			amplitude = constraints.SineTrajectoryMinAmplitude;
		}
		if(crest > constraints.SineTrajectoryMaxCrest) {
			crest = constraints.SineTrajectoryMaxCrest;
		}
		if(crest < constraints.SineTrajectoryMinCrest) {
			crest = constraints.SineTrajectoryMinCrest;
		}
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
