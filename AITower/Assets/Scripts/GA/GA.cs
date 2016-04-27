using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GA {
	// class reference
	private static GA instance;

	// member variables
	private List<Individual> population;
	private List<Individual> hallOfFame;
	private List<Individual> deadPopulation;

	// external functions
	private FitnessFunction fitnessFunction;

	// rates of mutation
	private float eulerRate;
	private float fractalRate;
	private float lineRate;
	private float sineRate;

	// total made of each
	private int eulerTotalCount;
	private int fractalTotalCount;
	private int lineTotalCount;
	private int sineTotalCount;

	// current made of each
	private int eulerCount;
	private int fractalCount;
	private int lineCount;
	private int sineCount;

	// total fitness of each (used for adaptive rates)
	private float eulerTotalFitness;
	private float fractalTotalFitness;
	private float lineTotalFitness;
	private float sineTotalFitness;

	// generation data
	private int numLiveBullets;

	///////////////// static methods ////////////////////
	static GA GetInstance() {
		return instance;
	}

	static void Initialize() {
		instance = new GA();
	}
	/////////////////////////////////////////////////////

	public GA() {
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

	private void InitializeVariables() { // TODO :: Fill In Rates
		eulerRate = 0.0f;
		fractalRate = 0.0f;
		lineRate = 0.0f;
		sineRate = 0.0f;
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
