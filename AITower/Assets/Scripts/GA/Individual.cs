using UnityEngine;
using System.Collections;

public class Individual {
	private Trajectory trajectory;

	Individual() {
		trajectory = null;
	}

	Individual(Trajectory traj) {
		trajectory = traj;
	}

	// getter methods
	Trajectory getTrajectory() { return trajectory; }

	// setter methods
	void setTrajectory(Trajectory param) { trajectory = param; }
}
