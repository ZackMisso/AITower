using UnityEngine;
using System.Collections;

public class Individual {
	private Trajectory trajectory;

	public Individual() {
		trajectory = null;
	}

	public Individual(Trajectory traj) {
		trajectory = traj;
	}

	// getter methods
	public Trajectory getTrajectory() { return trajectory; }

	// setter methods
	public void setTrajectory(Trajectory param) { trajectory = param; }
}
