using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
  public Trajectory trajectory;
  public int shotsInClip = 0; // 0 means it can not fire
  public int shotsRemaining = 0;
  public float reloadTime = 3.0f;
  private float timeReloadStart = 0.0f;
  private bool reloading = false;

  void Start() { }

	void Update() {
    if(reloading) {
      float currentTime = Time.time;
      if(currentTime < timeReloadStart + reloadTime) {
        reloading = false;
        shotsRemaining = shotsInClip;
      }
      // maybe add some UI stuff for the player... or add an extendable method
    }
  }

  public void Fire() {
    if(reloading || shotsInClip == 0 ) {
      Debug.Log("HUHUHUH");
      return;
    }
    // fire the shot
    // TO BE IMPLEMENTED
    Debug.Log("Firing");
    shotsRemaining--;

    //Trajectory traj = (Trajectory)Instantiate(trajectory, transform.position, Quaternion.identity);
    //traj.lineOfSight = transform.right;
		//traj.initialPosition = transform.position;

    ///////////// TEMPORARY CREATION CODE ///////////////////
    GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
    //bullet.AddComponent<Trajectory>();
    BulletController bc = bullet.GetComponent<BulletController>();
    bc.trajectory = trajectory;
    // check if the weapon should reload
    if(shotsRemaining == 0) {
      Debug.Log("WHAT");
      timeReloadStart = Time.time;
      reloading = true;
      // maybe add some UI stuff for the player... or add an extendable method
    }
  }
}
