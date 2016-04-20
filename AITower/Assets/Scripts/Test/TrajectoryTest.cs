using UnityEngine;
using System.Collections;

public class TrajectoryTest : MonoBehaviour {
  public Trajectory trajectory;

  void Start() {
    trajectory.BeginTrajectory();
  }

	void Update() {
    Debug.Log("Trajectory Test");
    trajectory.FollowTrajectory();
  }
}
