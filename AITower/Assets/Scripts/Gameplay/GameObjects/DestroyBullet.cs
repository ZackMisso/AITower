using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
    // This will need to be changed for GA. Trajectory should be updated
    if(other.gameObject.tag == "bulletDeath") {
      
      Destroy(other.gameObject);
    }
	}
}
