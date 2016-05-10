using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
  public Trajectory trajectory;
  public int trajID;
  public int trajType;
  public bool gaControlled = false;
  private float startTime;
  public bool moving = false;
  // there will also be more things later like material and particle effect

	void FixedUpdate() {
    if(moving)
      trajectory.FollowTrajectory(transform,Time.time-startTime);
  }

  public void StartMoving() {
    moving = true;
    startTime = Time.time;
  }

  void OnTriggerEnter(Collider other) {
    // Just in Case there is some multithreading issues
    //Debug.Log("AHAHAHA");
    trajectory = null;
    moving = false;
    Destroy(gameObject);
  }
}
