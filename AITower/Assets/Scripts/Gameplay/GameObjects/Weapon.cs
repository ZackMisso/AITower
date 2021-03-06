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
      if(currentTime > timeReloadStart + reloadTime) {
        reloading = false;
        shotsRemaining = shotsInClip;
      }
      // maybe add some UI stuff for the player... or add an extendable method
    }
  }

  public void Fire() {
    if(reloading || shotsInClip == 0 ) {
      return;
    }
    // fire the shot
    shotsRemaining--;
    GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
    BulletController bc = bullet.GetComponent<BulletController>();
    bc.trajectory = trajectory;
    bullet.transform.position = transform.position + 2.0f*transform.forward;
    bc.StartMoving();
    // check if the weapon should reload
    if(shotsRemaining == 0) {
      timeReloadStart = Time.time;
      reloading = true;
      // maybe add some UI stuff for the player... or add an extendable method
    }
  }
}
