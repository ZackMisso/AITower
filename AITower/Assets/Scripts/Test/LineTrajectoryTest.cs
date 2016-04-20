using UnityEngine;
using System.Collections;

public class LineTrajectoryTest : MonoBehaviour {
  public Trajectory trajectory;

  void Start() {
    trajectory.BeginTrajectory();
  }

	void Update() {
    Debug.Log("Line Trajectory Test");
    trajectory.FollowTrajectory();
  }
}
