using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
  public Trajectory trajectory;
  // there will also be more things later like material and particle effect

	void Update() {
    if(trajectory != null)
      trajectory.FollowTrajectory(transform);
  }

  // ToDo :: add Collision Code
}
