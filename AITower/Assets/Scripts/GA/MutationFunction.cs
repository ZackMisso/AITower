using UnityEngine;
using System.Collections;

public interface MutationFunction {
	Individual mutate(Individual individual);
}
