using UnityEngine;
using System.Collections;

public class SineTrajectory : Trajectory {
	public Vector3 sineMap = new Vector3(0.0f,1.0f,0.0f);
	public float amplitude = .05f;

	public override void FollowTrajectory() {
		float deltaTime = Time.time - lastUpdateTime;
		//Vector3 sineMap = (new Vector3(1.0f,1.0f,1.0f)) - lineOfSight;
    //Debug.Log(Mathf.Sin(Time.time)  * .01f);
		Debug.Log(initialPosition.y + lineOfSight.y * frequency * deltaTime);
    float dX = initialPosition.x + lineOfSight.x * frequency * deltaTime + sineMap.x * Mathf.Sin(Time.time) * amplitude;
    float dY = initialPosition.y + lineOfSight.y * frequency * deltaTime + sineMap.y * Mathf.Sin(Time.time) * amplitude;
    float dZ = initialPosition.z + lineOfSight.z * frequency * deltaTime + sineMap.z * Mathf.Sin(Time.time) * amplitude;
    transform.position = new Vector3(transform.position.x+dX,transform.position.y+dY,transform.position.z+dZ);
    lastUpdateTime = Time.time;
		// to be implemented
	}
}
