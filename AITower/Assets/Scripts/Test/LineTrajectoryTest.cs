using UnityEngine;
using System.Collections;

public class LineTrajectoryTest {
  public LineTrajectory trajectory = new LineTrajectory();

	void Update() {
    trajectory.FollowTrajectory();
  }
}
