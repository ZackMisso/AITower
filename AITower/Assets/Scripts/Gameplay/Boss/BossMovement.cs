using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
	public Transform outerLayer;
	public Transform innerLayer;

	public float outerAnimationTime = 1.0f;
	public float innerAnimationTime = 1.0f;

	public float maxAngleChange = 40.0f; // absolute value
	public float minAngleChange = 10.0f; // absolute value

	private bool animatingInner = false;
	private bool animatingOuter = false;
	private bool delayingInner = false;
	private bool delayingOuter = false;

	private float innerAnimationStart = 0.0f;
	private float outerAnimationStart = 0.0f;
	private float lastTimeStep = 0.0f;
	private Vector3 innerAnimation = new Vector3();
	private Vector3 outerAnimation = new Vector3();

	public float delayTime = 3.0f;
	public float delayChance = 0.1f;

	void Start() {
		innerAnimationStart = Time.time;
		outerAnimationStart = Time.time;
		delayingInner = true;
		delayingOuter = true;
	}

	void Update () {
		float innerAnimationProportion = (Time.time - lastTimeStep) / innerAnimationTime;
		if(innerAnimationProportion > 1.0f) {
			innerAnimationProportion = 1.0f;
		}

		float outerAnimationProportion = (Time.time - lastTimeStep) / outerAnimationTime;
		if(outerAnimationProportion > 1.0f) {
			outerAnimationProportion = 1.0f;
		}

		if(animatingInner && Time.time - innerAnimationStart >= innerAnimationTime) {
			if(animatingInner) {
				innerLayer.Rotate(innerAnimation * innerAnimationProportion);
			}
			endInnerAnimation();
		} else if(animatingInner) {
			innerLayer.Rotate(innerAnimation * innerAnimationProportion);
		}

		if(animatingOuter && Time.time - outerAnimationStart >= outerAnimationTime) {
			if(animatingOuter) {
				outerLayer.Rotate(outerAnimation * outerAnimationProportion);
			}
			endOuterAnimation();
		} else if(animatingOuter) {
			outerLayer.Rotate(outerAnimation * outerAnimationProportion);
		}

		if(delayingInner && Time.time - innerAnimationStart >= delayTime) {
			endInnerAnimation();
		}

		if(delayingOuter && Time.time - outerAnimationStart >= delayTime) {
			endOuterAnimation();
		}

		if(!animatingInner && !delayingInner) {
			float delayOrAnim = Random.value;
			if(delayOrAnim <= delayChance) {
				delayingInner = true;
			} else {
				animatingInner = true;
				float rotX = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				float rotY = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				float rotZ = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				if(Random.value < 0.5f)
					rotX = -rotX;
				if(Random.value < 0.5f)
					rotY = -rotY;
				if(Random.value < 0.5f)
					rotZ = -rotZ;
				innerAnimation = new Vector3(rotX,rotY,rotZ);
			}
			innerAnimationStart = Time.time;
		}

		if(!animatingOuter && !delayingOuter) {
			float delayOrAnim = Random.value;
			if(delayOrAnim <= delayChance) {
				delayingOuter = true;
			} else {
				animatingOuter = true;
				float rotX = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				float rotY = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				float rotZ = Random.value * (maxAngleChange - minAngleChange) + minAngleChange;
				if(Random.value < 0.5f)
					rotX = -rotX;
				if(Random.value < 0.5f)
					rotY = -rotY;
				if(Random.value < 0.5f)
					rotZ = -rotZ;
				outerAnimation = new Vector3(rotX,rotY,rotZ);
			}
			outerAnimationStart = Time.time;
		}

		lastTimeStep = Time.time;
	}

	private void endInnerAnimation() {
		animatingInner = false;
		delayingInner = false;
	}

	private void endOuterAnimation() {
		animatingOuter = false;
		delayingOuter = false;
	}
}
