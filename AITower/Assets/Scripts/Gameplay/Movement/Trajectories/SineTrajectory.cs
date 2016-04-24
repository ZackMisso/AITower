using UnityEngine;
using System.Collections;

public class SineTrajectory : Trajectory {
	public Vector3 sineMap = new Vector3(0.0f,1.0f,0.0f);
	public float amplitude = 1.0f;
	//public float length = 0.0f;

	public override void FollowTrajectory(Transform currentTransform) {
		float length = Time.time - startTime;
		//Vector3 sineMap = (new Vector3(1.0f,1.0f,1.0f)) - lineOfSight;
    //Debug.Log(Mathf.Sin(Time.time) * amplitude);
		//Debug.Log(initialPosition.y + lineOfSight.y * frequency * deltaTime);
		float newX = initialPosition.x + lineOfSight.x*length;
		float newY = initialPosition.y + lineOfSight.y*length;
		float newZ = initialPosition.z + lineOfSight.z*length;
    float dX = sineMap.x * Mathf.Sin(Time.time) * amplitude;
    float dY = sineMap.y * Mathf.Sin(Time.time) * amplitude;
    float dZ = sineMap.z * Mathf.Sin(Time.time) * amplitude;
    currentTransform.position = new Vector3(newX+dX,newY+dY,newZ+dZ);
    //lastUpdateTime = Time.time;
	}
}
