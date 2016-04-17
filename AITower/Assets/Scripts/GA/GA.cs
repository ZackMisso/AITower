using UnityEngine;
using System.Collections;
using System.Collections.ArrayList;

public class GA {
	// class reference
	static GA instance;
	// member variables
	ArrayList population;
	ArrayList futurePopulation;
	ArrayList deadPopulation;
	ArrayList hallOfFame;

	ArrayList mutationFunctions;
	FitnessFunction fitnessFunction;

	///////////////// static methods ////////////////////
	static GA GetInstance() {
		return instance;
	}

	static void Initialize() {
		instance = new GA();
	}
	/////////////////////////////////////////////////////

	GA() {
		population = new ArrayList();
		futurePopulation = new ArrayList();
		mutationFunctions = new ArrayList();
		deadPopulation = new ArrayList();
		hallOfFame = new ArrayList();
		fitnessFunction = new PlayerDistFitness();
		InitializePopulation();
	}

	void InitializePopulation() {
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
