using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {
  public PGSystem pgRef;
  public GA gaRef;
  public Death playerDeath;
  public Vector3 spawnPoint;
  public float startTime = -1.0f;
  public float lengthOfFight;
  private int counter;
  private bool bossFighting = false;
  public int spawnNums = 5;

  void Start() {
    //system.isBoss = true;
    spawnPoint = gameObject.transform.position;
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
      DisplayEndState();
    }
    //Debug.Log("Updating Boss");
    if(bossFighting) {
      for(int i=0;i<spawnNums;i++) {
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

  public void DisplayEndState() {
    SceneManager.LoadScene("WinScene");
  }

  void OnGUI() {
    string timerString = "Time Left: " + (int)((lengthOfFight - (Time.time-startTime)));
    GUI.Box(new Rect(5,5,80,25),timerString,playerDeath.style);
  }
}
