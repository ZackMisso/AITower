using UnityEngine;
using System.Collections;

public interface MutationFunction : MonoBehaviour {
	Individual mutate(Individual individual);
}
