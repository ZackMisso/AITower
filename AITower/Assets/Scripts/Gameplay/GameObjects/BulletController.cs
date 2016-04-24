using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
  public Trajectory trajectory;
  public bool moving = false;
  // there will also be more things later like material and particle effect

	void Update() {
    //Debug.Log(transform.position.x);
    //if(trajectory != null) {
    //  Debug.Log(transform.position.x);
    if(moving)
      trajectory.FollowTrajectory(transform);
    //} else {
    //  Debug.Log("Trajectory is Null");
    //}
  }

  // ToDo :: add Collision Code
}
