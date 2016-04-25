using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	private Weapon weapon;

	// Use this for initialization
	void Start () {
		weapon = gameObject.GetComponent<Weapon>();
		if(weapon == null) {
			Debug.Log("Error :: Turret Must have a Weapon Attached");
		}
	}

	// Update is called once per frame
	void Update () {
		weapon.Fire();
	}
}
