using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
  public PGSystem pgRef;
  public GA gaRef;
  public Vector3 spawnPoint;
  public float startTime;
  public float lengthOfFight;

  void Start() {
    //system.isBoss = true;
    spawnPoint = gameObject.transform.position;
    // to be implemented
  }

	void Update () {
    for(int i=0;i<5;i++) {
      GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
      bullet.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
      ///////////////////// Test Code /////////////////////////////////////
      float x = (Random.value - 0.5f) * 2.0f;
      float y = Random.value * 0.5f - 0.8f;
      float z = (Random.value - 0.5f) * 2.0f;
      bullet.AddComponent<LineTrajectory>();
      LineTrajectory tmp = bullet.GetComponent<LineTrajectory>();
      tmp.lineOfSight = new Vector3(x,y,z);
      //Debug.Log(tmp.lineOfSight.y);
      tmp.initialPosition = gameObject.transform.position;
      tmp.speed = 0.3f;
      /////////////////////////////////////////////////////////////////////
      ///////////////////// Real Code /////////////////////////////////////
      //int trajID = gaRef.GetNextIndividual(bullet);
      /////////////////////////////////////////////////////////////////////
      tmp.isBoss = true;
      BulletController bc = bullet.GetComponent<BulletController>();
      //bc.trajID = trajID;
      bc.StartMoving();
      bc.trajectory = tmp;
    }
  }
}
