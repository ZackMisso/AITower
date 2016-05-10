using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
  public PGSystem system;
  public Vector3 spawnPoint;
  public float startTime;
  public float lengthOfFight;

  void Start() {
    //system.isBoss = true;
    spawnPoint = gameObject.transform.position;
    // to be implemented
  }

	void Update () {
    for(int i=0;i<3;i++) {
      GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
      bullet.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
      float x = (Random.value - 0.5f) * 2.0f;
      float y = Random.value * 0.5f - 0.8f;
      float z = (Random.value - 0.5f) * 2.0f;
      bullet.AddComponent<LineTrajectory>();
      LineTrajectory tmp = bullet.GetComponent<LineTrajectory>();
      tmp.lineOfSight = new Vector3(x,y,z);
      Debug.Log(tmp.lineOfSight.y);
      tmp.initialPosition = gameObject.transform.position;
      tmp.speed = 0.5f;
      tmp.isBoss = true;
      BulletController bc = bullet.GetComponent<BulletController>();
      bc.StartMoving();
      bc.trajectory = tmp;
    }
  }
}
