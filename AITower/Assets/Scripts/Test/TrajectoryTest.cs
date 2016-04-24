using UnityEngine;
using System.Collections;

public class TrajectoryTest : MonoBehaviour {
  public Trajectory trajectory;

  void Start() {
    trajectory.BeginTrajectory(transform);
  }

	void Update() {
    Debug.Log("Trajectory Test");
    trajectory.FollowTrajectory(transform);
  }
}
