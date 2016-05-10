using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GA : MonoBehaviour {
	public Constraints constraints;

	// member variables
	private List<Individual> population;
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
		population = new List<Individual>();
		hallOfFame = new List<Individual>();
		deadPopulation = new List<Individual>();
		fitnessFunction = new PlayerDistFitness();
	}

	public void StartGA() {
		InitializeVariables();
		InitializePopulation();
		SendNextWave();
	}

	public int GetNextIndividual(GameObject bullet) {
		// to be implemented
		return -1;
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
		// first initialization
		// to be implemented
	}

	void MakeDead(Individual individual) {
		// tells the GA that the parameter individual can now be used for future
		// mutations. Its Fitness gets evaluated and added to the list of dead
		// sorted by its fitness
		// to be implemented
	}

	void EvaluateDead() {
		// gets the individuals that have died and generates new population based on
		// the dead individuals and the hall of fame individuals. This method gets
		// called if there are enough dead individuals in the dead list.
		// to be implemented
	}

	void SendNextWave() {
		// adds members from the future population to the current population
		// to be implemented
	}
}
