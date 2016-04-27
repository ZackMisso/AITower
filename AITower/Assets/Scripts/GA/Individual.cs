using UnityEngine;
using System.Collections;

// This class seems useless but it is for speed optimizations.
// The GA algorithm evolves old trajectories and replaces them with new ones
// Replacing a trajectory requires removing the old one from a List datastructure
// Which is O(N) worst case. By placing the Trajectories in an individual class
// we can just replace the trajectory within the individual and not have to worry
// about time spent replacing objects in lists

public class Individual {
	private Trajectory trajectory;
	private float fitness;
	private bool waitingToFire;
	private bool dead;

	public Individual() {
		trajectory = null;
		fitness = 0.0f;
		waitingToFire = false;
		dead = false;
	}

	public Individual(Trajectory traj) {
		trajectory = traj;
		fitness = 0.0f;
		waitingToFire = true;
		dead = false;
	}

	// getter methods
	public Trajectory getTrajectory() { return trajectory; }
	public float getFitness() { return fitness; }
	public bool getWaitingToFire() { return waitingToFire; }
	public bool getDead() { return dead; }

	// setter methods
	public void setTrajectory(Trajectory param) { trajectory = param; }
	public void setFitness(float param) { fitness = param; }
	public void setWaitingToFire(bool param) { waitingToFire = param; }
	public void setDead(bool param) { dead = param; }
}
