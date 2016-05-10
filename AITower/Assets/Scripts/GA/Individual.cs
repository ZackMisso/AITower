using UnityEngine;
using System.Collections;

// This class seems useless but it is for speed optimizations.
// The GA algorithm evolves old trajectories and replaces them with new ones
// Replacing a trajectory requires removing the old one from a List datastructure
// Which is O(N) worst case. By placing the Trajectories in an individual class
// we can just replace the trajectory within the individual and not have to worry
// about time spent replacing objects in lists

public class Individual {
	public GameObject bullet;
	public Trajectory trajectory;
	public int trajType;
	public float fitness;
	public bool waitingToFire;
	public bool dead;

	public Individual() {
		bullet = null;
		trajectory = null;
		fitness = 0.0f;
		waitingToFire = false;
		dead = false;
	}

	public Individual(GameObject obj) {
		bullet = obj;
		//BulletController bc = obj.GetComponent<BulletController>();
		//if(bc.trajType = 1) {
		//	trajectory = obj.GetComponent<LineTrajectory>();
		//} else if(bc.trajType = 2) {
		//	trajectory = obj.GetComponent<FractalTrajectory>();
		//} else if(bc.trajType = 3) {
		//	trajectory = obj.GetComponent<SineTrajectory>();
		//} else if(bc.trajType = 4) {
		//	trajectory = obj.GetComponent<EulerTrajectory>();
		//}
		//trajType = bc.trajType;
		trajType = -1;
		fitness = 0.0f;
		waitingToFire = true;
		dead = false;
	}

	public void CleanBullet() {
		//bullet.Destroy(trajectory); // not sure if this works or not
		trajectory = null;

		/*if(bc.trajType == 1) {
			Destroy(GetComponent<LineTrajectory>());
		} else if(bc.trajType == 2) {
			Destroy(GetComponent<FractalTrajectory>());
		} else if(bc.trajType == 3) {
			Destroy(GetComponent<SineTrajectory>());
		} else if(bc.trajType == 4) {
			Destroy(GetComponent<EulerTrajectory>());
		}
		*/
	}
}
