using UnityEngine;
using System.Collections;

public class LineTrajectory : Trajectory {
	public override void FollowTrajectory() {
    float deltaTime = Time.time - lastUpdateTime;
    Debug.Log(deltaTime);
    float newX = transform.position.x + lineOfSight.x * frequency * deltaTime;
    float newY = transform.position.y + lineOfSight.y * frequency * deltaTime;
    float newZ = transform.position.z + lineOfSight.z * frequency * deltaTime;
    transform.position = new Vector3(newX,newY,newZ);
    lastUpdateTime = Time.time;
	}
}
