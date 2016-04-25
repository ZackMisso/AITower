using UnityEngine;
using System.Collections;

public class LineTrajectory : Trajectory {
	public override void FollowTrajectory(Transform currentTransform) {
    float newX = currentTransform.position.x + lineOfSight.x * frequency;
    float newY = currentTransform.position.y + lineOfSight.y * frequency;
    float newZ = currentTransform.position.z + lineOfSight.z * frequency;
    currentTransform.position = new Vector3(newX,newY,newZ);
	}
}
