using UnityEngine;
using System.Collections;

public interface FitnessFunction {
	float EvaluateFitness(Individual individual);
}
