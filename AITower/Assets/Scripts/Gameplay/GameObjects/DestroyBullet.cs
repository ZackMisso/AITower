using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {
	public PGSystem pgRef = null;
	public GA gaRef = null;
	public bool isWall = false;

	void Start() {
		if(isWall) {
			if(pgRef == null) {
				Debug.Log("Destroy Bullet Needs Reference to PGSystem");
			}
			if(gaRef == null) {
				Debug.Log("Destroy Bullet Needs Reference to GA");
			}
		}
	}

	void OnTriggerEnter(Collider other) {
    // This will need to be changed for GA. Trajectory should be updated
    if(other.gameObject.tag == "bulletDeath") {
			if(pgRef.isBoss) {
				BulletController bc = other.gameObject.GetComponent<BulletController>();
				if(bc.gaControlled) {
					gaRef.MakeIndividualDead(bc.trajID);
				}
			} else {
      	Destroy(other.gameObject);
			}
    }
	}
}
