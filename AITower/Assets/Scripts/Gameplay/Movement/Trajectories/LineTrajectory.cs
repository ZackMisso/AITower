using UnityEngine;
using System.Collections;

public class LineTrajectory : Trajectory {
	public override void FollowTrajectory(Transform currentTransform) {
    float newX = currentTransform.position.x + lineOfSight.x * speed;
    float newY = currentTransform.position.y + lineOfSight.y * speed;
    float newZ = currentTransform.position.z + lineOfSight.z * speed;
    currentTransform.position = new Vector3(newX,newY,newZ);
	}
}
