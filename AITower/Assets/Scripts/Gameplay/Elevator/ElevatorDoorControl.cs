using UnityEngine;
using System.Collections;

public class ElevatorDoorControl : MonoBehaviour {
  public float animationTime = 1.0f;
  public Vector3 openPosition = new Vector3();
  public Vector3 closePosition = new Vector3();
  private float animationStart = 0.0f;
  private bool isClosing = false;
  private bool isOpening = false;
  private bool isClosed = false;

  public void Open() {
    if(isClosed && !isClosing && !isOpening) {
      animationStart = Time.time;
      // some of these are redundant but doing them just in case
      isClosed = false;
      isClosing = false;
      isOpening = true;
    }
  }

  public void Close() {
    if(!isClosed && !isOpening && !isClosing) {
      animationStart = Time.time;
      // some of these are redundant but doing them just in case
      isClosed = false;
      isClosing = true;
      isOpening = false;
    }
  }

	// Update is called once per frame
	void Update () {
    if(isOpening) {
      Vector3 move = closePosition - openPosition;
      float dt = (Time.time - animationStart) / animationTime;
      if(dt>=1.0f) {
        dt = 1.0f;
        isOpening = false;
        isClosed = false; // probably redundant
      }
      gameObject.transform.position = closePosition + move * dt;
    }
    if(isClosing) {
      Vector3 move = openPosition - closePosition;
      float dt = (Time.time - animationStart) / animationTime;
      if(dt>=1.0f) {
        dt = 1.0f;
        isClosing = false;
        isClosed = true;
      }
      gameObject.transform.position = closePosition + move * dt;
    }
  }
}
