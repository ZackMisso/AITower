using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
  public Trajectory trajectory;
  private float startTime;
  private bool moving = false;
  // there will also be more things later like material and particle effect

	void FixedUpdate() {
    if(moving)
      trajectory.FollowTrajectory(transform,Time.time-startTime);
  }

  public void StartMoving() {
    moving = true;
    startTime = Time.time;
  }

  // ToDo :: add Collision Code
}
