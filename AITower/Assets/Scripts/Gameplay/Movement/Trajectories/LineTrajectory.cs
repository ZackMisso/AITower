using UnityEngine;
using System.Collections;

public class LineTrajectory : Trajectory {
	public override void FollowTrajectory(Transform currentTransform) {
    float deltaTime = Time.time - lastUpdateTime;
    //Debug.Log(deltaTime);
    float newX = currentTransform.position.x + lineOfSight.x * frequency * deltaTime;
    float newY = currentTransform.position.y + lineOfSight.y * frequency * deltaTime;
    float newZ = currentTransform.position.z + lineOfSight.z * frequency * deltaTime;
    currentTransform.position = new Vector3(newX,newY,newZ);
    lastUpdateTime = Time.time;
	}
}
