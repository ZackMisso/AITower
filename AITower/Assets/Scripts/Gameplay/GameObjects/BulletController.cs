using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
  public Trajectory trajectory;
  public bool moving = false;
  // there will also be more things later like material and particle effect

	void FixedUpdate() {
    if(moving)
      trajectory.FollowTrajectory(transform);
  }

  // ToDo :: add Collision Code
}
