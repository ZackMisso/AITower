using UnityEngine;
using System.Collections;

public class ElevatorDoorControl : MonoBehaviour {
  public float animationTime = 1.0f;
  public float openXPosition = 0.0f;
  public float closeXPosition = 0.0f;
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
      float move = openXPosition - closeXPosition;
      float dt = (Time.time - animationStart) / animationTime;
      if(dt>=1.0f) {
        dt = 1.0f;
        isOpening = false;
        isClosed = false; // probably redundant
      }
      transform.position = new Vector3(closeXPosition + move * dt,transform.position.y,transform.position.z);
    }
    if(isClosing) {
      float move = closeXPosition - openXPosition;
      //float move = openXPosition - closeXPosition;
      float dt = (Time.time - animationStart) / animationTime;
      if(dt>=1.0f) {
        dt = 1.0f;
        isClosing = false;
        isClosed = true;
      }
      //transform.position = new Vector3(closeXPosition + move * dt,transform.position.y,transform.position.z);
      transform.position = new Vector3(openXPosition + move * dt,transform.position.y,transform.position.z);
    }
  }
}
