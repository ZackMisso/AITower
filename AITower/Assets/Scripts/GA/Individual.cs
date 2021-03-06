﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public int id;
	public float fitness;
	public bool waitingToFire;
	public bool dead;

	private BulletController bc;

	public Individual(int num) {
		bullet = null;
		trajectory = null;
		fitness = 0.0f;
		waitingToFire = false;
		dead = false;
		id = num;
	}

	public Individual(GameObject obj,int num) {
		bullet = obj;
		trajType = -1;
		fitness = 0.0f;
		waitingToFire = true;
		dead = false;
		id=num;
	}

	public void SetUpBullet() {
		bc = bullet.GetComponent<BulletController>();
		bc.trajID = id;
		bc.gaControlled = true;
		bc.trajectory = trajectory;
		if(trajectory == null) {
			Debug.Log("Major Error");
		}
	}

	public static List<Individual> Sort(List<Individual> individuals) {
		if(individuals.Count <= 1) {
			return individuals;
		}
		List<Individual> one = new List<Individual>();
		List<Individual> two = new List<Individual>();
		int i=0;
		for(;i<individuals.Count/2;i++) {
			one.Add(individuals[i]);
		}
		for(;i<individuals.Count;i++) {
			two.Add(individuals[i]);
		}
		return Merge(Sort(one),Sort(two));
	}

	public static List<Individual> Merge(List<Individual> one, List<Individual> two) {
		List<Individual> sorted = new List<Individual>();
		int i = 0;
		int j = 0;
		while(one.Count > i && two.Count > j) {
			if(one[i].fitness < two[j].fitness) {
				sorted.Add(one[i]);
				i++;
			} else {
				sorted.Add(two[j]);
				j++;
			}
		}
		while(one.Count > i) {
			sorted.Add(one[i]);
			i++;
		}
		while(two.Count > j) {
			sorted.Add(two[j]);
			j++;
		}
		return sorted;
	}
}
