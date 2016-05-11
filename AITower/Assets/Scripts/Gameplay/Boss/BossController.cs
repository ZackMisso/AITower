using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
  public PGSystem pgRef;
  public GA gaRef;
  public Vector3 spawnPoint;
  public float startTime = -1.0f;
  public float lengthOfFight;
  private int counter;
  private bool bossFighting = false;

  void Start() {
    //system.isBoss = true;
    spawnPoint = gameObject.transform.position;
    // to be implemented
  }

  public void ResetBoss() {
    startTime = -1.0f;
  }

	void Update () {
    if(startTime == -1.0f) {
      startTime = Time.time;
      bossFighting = true;
    }
    if(Time.time - startTime >= lengthOfFight && bossFighting) {
      bossFighting = false;
    }
    //Debug.Log("Updating Boss");
    if(bossFighting) {
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
}
