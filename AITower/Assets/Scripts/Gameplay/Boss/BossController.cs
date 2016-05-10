using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
  public PGSystem pgRef;
  public GA gaRef;
  public Vector3 spawnPoint;
  public float startTime;
  public float lengthOfFight;
  private int counter;

  void Start() {
    //system.isBoss = true;
    spawnPoint = gameObject.transform.position;
    // to be implemented
  }

	void Update () {
    //Debug.Log("Updating Boss");
    for(int i=0;i<5;i++) {
      Individual bullet = gaRef.GetNextIndividual();
      if(bullet != null) {
        bullet.trajectory.initialPosition = gameObject.transform.position;
        bullet.bullet.transform.position = gameObject.transform.position;
        BulletController bc = bullet.bullet.GetComponent<BulletController>();
        bc.StartMoving();
      }
    }
  }
}
