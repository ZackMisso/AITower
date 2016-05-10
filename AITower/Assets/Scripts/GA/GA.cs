using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GA : MonoBehaviour {
	public Constraints constraints;
	public Transform playerTransform;
	public Transform bossTransform;

	// member variables
	private List<Individual> population;
	private List<Individual> readyPopulation;
	private List<Individual> hallOfFame;
	private List<Individual> deadPopulation;

	// external functions
	private FitnessFunction fitnessFunction;

	// rates of mutation
	public float eulerRate;
	public float fractalRate;
	public float lineRate;
	public float sineRate;

	// total made of each
	public int eulerTotalCount;
	public int fractalTotalCount;
	public int lineTotalCount;
	public int sineTotalCount;

	// current made of each
	public int eulerCount;
	public int fractalCount;
	public int lineCount;
	public int sineCount;

	// total fitness of each (used for adaptive rates)
	public float eulerTotalFitness;
	public float fractalTotalFitness;
	public float lineTotalFitness;
	public float sineTotalFitness;

	// generation data
	public int numLiveBullets;

	void Start() {
		constraints = GetComponent<Constraints>();
		if(constraints == null) {
			Debug.Log("Error.. GA Needs a Ref to Constraints");
		}
		if(playerTransform == null) {
			Debug.Log("Error.. Player Transform Needs to Not be Null");
		}
		if(bossTransform == null) {
			Debug.Log("Error.. Boss Transform Needs to Not be Null");
		}
		population = new List<Individual>();
		readyPopulation = new List<Individual>();
		hallOfFame = new List<Individual>();
		deadPopulation = new List<Individual>();
		fitnessFunction = new PlayerDistFitness();
	}

	public void StartGA() {
		InitializeVariables();
		InitializePopulation();
		//SendNextWave();
	}

	public Individual GetNextIndividual() {
		if(readyPopulation.Count == 0) {
			Debug.Log("Error... NOT ENOUGH POPULATION IN BOSS FIGHT");
			return null;
		}
		// Removing at the end is O(1). Removing at the beginning is O(n).
		// It is possible that the beginning individuals never make it to the
		// scene but the performance boost is worth it.
		Individual toRet = readyPopulation[readyPopulation.Count-1];
		Debug.Log("Getting Ind: "+toRet.trajectory.lineOfSight);
		readyPopulation.RemoveAt(readyPopulation.Count-1);
		return toRet;
	}

	// tells the GA that the parameter individual can now be used for future
	// mutations. Its Fitness gets evaluated and added to the list of dead
	// sorted by its fitness
	public void MakeIndividualDead(int id) {
		Individual ind = population[id];
		// calculate fitness
		Vector3 dist = ind.bullet.transform.position - playerTransform.position;
		ind.fitness = dist.sqrMagnitude;
		// move the bullet out of view
		ind.bullet.transform.position = new Vector3(0.0f,-20.0f,0.0f);
		// add individual to list of dead
		deadPopulation.Add(ind);
		// if list of dead is > 40 in size then evolve and replace
		if(deadPopulation.Count == 40) {
			// sort the list of dead individuals by their fitness
			deadPopulation = Individual.Sort(deadPopulation);
			for(int i=39;i>=0;i++) {
				Individual individual = deadPopulation[i];
				if(i < 10) {
					// only mutate :: to make things easier
					individual.trajectory.Mutate(constraints);
				} else {
					// crossover and mutate :: to make things simpler
					Individual toCross = deadPopulation[Random.Range(0,10)];
					individual.trajectory.Crossover(constraints,toCross.trajectory);
					individual.trajectory.PostCrossoverMutate(constraints);
				}
				// make the individual ready
				readyPopulation.Add(individual);
			}
		}
		// empty dead list
		deadPopulation.Clear();
		// error check
		if(deadPopulation.Count > 40) {
			Debug.Log("Dead Population Is Too Big... Major Errors");
		}
	}

	private void InitializeVariables() { // TODO :: Fill In Rates
		eulerRate = 30.0f;
		fractalRate = 0.0f;
		lineRate = 40.0f;
		sineRate = 30.0f;
		eulerCount = 0;
		fractalCount = 0;
		lineCount = 0;
		sineCount = 0;
		eulerTotalCount = 0;
		fractalTotalCount = 0;
		lineTotalCount = 0;
		sineTotalCount = 0;
		eulerTotalFitness = 0.0f;
		fractalTotalFitness = 0.0f;
		lineTotalFitness = 0.0f;
		sineTotalFitness = 0.0f;
		numLiveBullets = 0;
	}

	private void InitializePopulation() {
		for(int i=0;i<800;i++) {
			population.Add(new Individual(i));
			CreateBullet(population[i]);
			readyPopulation.Add(population[i]);
			//Debug.Log("Creating Bullet: " + i);
		}
		int k=0;
		int numEuler = (int)(800.0f * eulerRate / 100.0f);
		int numLine = (int)(800.0f * sineRate / 100.0f);
		int numFractal = (int)(800.0f * fractalRate / 100.0f);
		int numSine = (int)(800.0f * sineRate / 100.0f);
		for(int j=0;j<numEuler;j++) {
			//Debug.Log("Making Bullet: "+k);
			CreateRandomEulerTrajectory(population[k]);
			k++;
		}
		for(int j=0;j<numLine;j++) {
			//Debug.Log("Making Bullet: "+k);
			CreateRandomLineTrajectory(population[k]);
			k++;
		}
		for(int j=0;j<numSine;j++) {
			//Debug.Log("Making Bullet: "+k);
			CreateRandomSineTrajectory(population[k]);
			k++;
		}
		//for(int j=0;j<numFractal;j++) {
		for(int j=0;j<0;j++) {
			//Debug.Log("Making Bullet: "+k);
			CreateRandomFractalTrajectory(population[k]);
			k++;
		}
		while(k<800) {
			//Debug.Log("Making Bullet: "+k);
			CreateRandomLineTrajectory(population[k]);
			k++;
		}
		for(int i=0;i<800;i++) {
			population[i].SetUpBullet();
		}
	}

	private Vector3 CreateRandomLineOfSight() {
		float x = (Random.value - 0.5f) * 2.0f;
		float y = (Random.value * 0.5f) - 0.8f;
		float z = (Random.value - 0.5f) * 2.0f;
		Vector3 los = new Vector3(x,y,z);
		los.Normalize();
		return los;
	}

	private void CleanIndividual(Individual individual) {
		int trajType = individual.trajType;
		if(trajType == 1) {
			Destroy(individual.bullet.GetComponent<LineTrajectory>());
		} else if(trajType == 2) {
			Destroy(individual.bullet.GetComponent<FractalTrajectory>());
		} else if(trajType == 3) {
			Destroy(individual.bullet.GetComponent<SineTrajectory>());
		} else if(trajType == 4) {
			Destroy(individual.bullet.GetComponent<EulerTrajectory>());
		}
	}

	private void CreateBullet(Individual individual) {
		//Debug.Log("Creating Bullet");
		individual.bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
		//individual.bullet.transform.position = new Vector3(bossTransform.position.x,bossTransform.position.y,bossTransform.position.z);
		individual.bullet.transform.position = new Vector3(0.0f,-20.0f,0.0f);
		// might need to implement more
	}

	private void CreateRandomEulerTrajectory(Individual individual) {
		individual.bullet.AddComponent<EulerTrajectory>();
		EulerTrajectory traj = individual.bullet.GetComponent<EulerTrajectory>();
		individual.trajType = 4;
		// shared data
		Vector3 lineOfSight = CreateRandomLineOfSight();
		float speed = Random.value * (constraints.TrajectoryMaxSpeed - constraints.TrajectoryMinSpeed) + constraints.TrajectoryMinSpeed;
		traj.speed = speed;
		traj.lineOfSight = lineOfSight;
		//Debug.Log(traj.lineOfSight);
		// traj spacific data
		traj.acceleration = Random.value * (constraints.EulerTrajectoryMaxAcceleration - constraints.EulerTrajectoryMinAcceleration) + constraints.EulerTrajectoryMinAcceleration;
		traj.startingYVelocity = Random.value * (constraints.EulerTrajectoryMaxStartingYVelocity - constraints.EulerTrajectoryMinStartingYVelocity) + constraints.EulerTrajectoryMinStartingYVelocity;
		// set the trajectory
		individual.trajectory = traj;
	}

	private void CreateRandomFractalTrajectory(Individual individual) {
		individual.bullet.AddComponent<FractalTrajectory>();
		FractalTrajectory traj = individual.bullet.GetComponent<FractalTrajectory>();
		individual.trajType = 2;
		// shared data
		Vector3 lineOfSight = CreateRandomLineOfSight();
		float speed = Random.value * (constraints.TrajectoryMaxSpeed - constraints.TrajectoryMinSpeed) + constraints.TrajectoryMinSpeed;
		traj.speed = speed;
		traj.lineOfSight = lineOfSight;
		// traj spacific data
		// have to implement fractal first
		// set the trajectory
		individual.trajectory = traj;
	}

	private void CreateRandomLineTrajectory(Individual individual) {
		individual.bullet.AddComponent<LineTrajectory>();
		LineTrajectory traj = individual.bullet.GetComponent<LineTrajectory>();
		individual.trajType = 1;
		// shared data
		Vector3 lineOfSight = CreateRandomLineOfSight();
		float speed = Random.value * (constraints.TrajectoryMaxSpeed - constraints.TrajectoryMinSpeed) + constraints.TrajectoryMinSpeed;
		traj.speed = speed;
		traj.lineOfSight = lineOfSight;
		// traj spacific data
		// there is none for line
		// set the trajectory
		individual.trajectory = traj;
	}

	private void CreateRandomSineTrajectory(Individual individual) {
		individual.bullet.AddComponent<SineTrajectory>();
		SineTrajectory traj = individual.bullet.GetComponent<SineTrajectory>();
		individual.trajType = 3;
		// shared data
		Vector3 lineOfSight = CreateRandomLineOfSight();
		float speed = Random.value * (constraints.TrajectoryMaxSpeed - constraints.TrajectoryMinSpeed) + constraints.TrajectoryMinSpeed;
		traj.speed = speed;
		traj.lineOfSight = lineOfSight;
		// traj spacific data
		traj.amplitude = Random.value * (constraints.SineTrajectoryMaxAmplitude - constraints.SineTrajectoryMinAmplitude) + constraints.SineTrajectoryMinAmplitude;
		traj.crest = Random.value * (constraints.SineTrajectoryMaxCrest - constraints.SineTrajectoryMinCrest) + constraints.SineTrajectoryMinCrest;
		// set the trajectory
		individual.trajectory = traj;
	}
}
