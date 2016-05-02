using UnityEngine;
//using System;
using System.Collections;

// I know this class is written poorly but I am in a rush

public class BossLights : MonoBehaviour {
	public Light lightOne;
	public Light lightTwo;
	public Light lightThree;
	public Light lightFour;

	public Color firstColor = Color.red;
	public Color secondColor = Color.green;
	public Color thirdColor = Color.blue;
	public Color fourthColor = Color.grey;

	private int currentColorIndex = 2; // blue
	private int nextColorIndex;
	private float minAngle = 70.0f;
	public float maxAngle = 150.0f;
	private Color prevColor;

	private float angle;
	private int endColor;
	public float angleAnimationTime = 10.0f;
	public float colorAnimationTime = 6.0f;
	public float rotateChance = 0.5f;
	private float lastTimeStep;
	private float startTime;

	private bool rotatingLights;
	private bool changingColor;

	// Use this for initialization
	void Start () {
		prevColor = thirdColor;
		lastTimeStep = 0.0f;
		startTime = 0.0f;
		rotatingLights = false;
		changingColor = false;
		UpdateColors(prevColor);
	}

	// inefficient but i have a lot on my plate so it can be fixed later
	void Update () {
		float rotAnimationProportion = (Time.time - lastTimeStep) / angleAnimationTime;
		if(rotAnimationProportion > 1.0f) {
			rotAnimationProportion = 1.0f;
		}

		float colAnimationProportion = (Time.time - startTime) / colorAnimationTime;
		if(colAnimationProportion > 1.0f) {
			colAnimationProportion = 1.0f;
		}

		Color desired = getDesiredColor();
		Color currentColor = new Color();

		if(changingColor && Time.time - startTime >= colorAnimationTime) {
			currentColor.r = (desired.r - prevColor.r) * colAnimationProportion + prevColor.r;
			currentColor.g = (desired.g - prevColor.g) * colAnimationProportion + prevColor.g;
			currentColor.b = (desired.b - prevColor.b) * colAnimationProportion + prevColor.b;
			currentColor.a = 255.0f; //Abs(desired.a - prevColor.a) * colAnimationProportion;
			UpdateColors(currentColor);
			changingColor = false;
			prevColor = desired;
		} else if(changingColor) {
			currentColor.r = (desired.r - prevColor.r) * colAnimationProportion + prevColor.r;
			currentColor.g = (desired.g - prevColor.g) * colAnimationProportion + prevColor.g;
			currentColor.b = (desired.b - prevColor.b) * colAnimationProportion + prevColor.b;
			UpdateColors(currentColor);
			currentColor.a = 255.0f; //Abs(desired.a - prevColor.a) * colAnimationProportion;
		}

		if(rotatingLights && Time.time - startTime >= angleAnimationTime) {
			lightOne.transform.Rotate(Vector3.up * rotAnimationProportion * angle,Space.World);
			lightTwo.transform.Rotate(Vector3.up * rotAnimationProportion * angle,Space.World);
			lightThree.transform.Rotate(Vector3.up * rotAnimationProportion * angle,Space.World);
			lightFour.transform.Rotate(Vector3.up * rotAnimationProportion * angle,Space.World);
			rotatingLights = false;
		} else if(rotatingLights) {
			lightOne.transform.Rotate(Vector3.up * rotAnimationProportion * angle);
			lightTwo.transform.Rotate(Vector3.up * rotAnimationProportion * angle);
			lightThree.transform.Rotate(Vector3.up * rotAnimationProportion * angle);
			lightFour.transform.Rotate(Vector3.up * rotAnimationProportion * angle);
		}

		if(!rotatingLights && !changingColor) {
			float colorOrRot = Random.value;
			if(colorOrRot > rotateChance) {
				changingColor = true;
				startTime = Time.time;
				float ind = Random.value;
				if(ind < 0.25f)
					nextColorIndex = 0;
				else if(ind < 0.5f)
					nextColorIndex = 1;
				else if(ind < 0.75f)
					nextColorIndex = 2;
				else
					nextColorIndex = 3;
			} else {
				rotatingLights = true;
				startTime = Time.time;
				angle = Random.value * (maxAngle - minAngle) + minAngle;
			}
		}

		//UpdateColors(currentColor);
		lastTimeStep = Time.time;
	}

	private void UpdateColors(Color current) {
		lightOne.color = current;
		lightTwo.color = current;
		lightThree.color = current;
		lightFour.color = current;
	}

	private Color getDesiredColor() {
		if(nextColorIndex == 0)
			return firstColor;
		if(nextColorIndex == 1)
			return secondColor;
		if(nextColorIndex == 2)
			return thirdColor;
		return fourthColor;
	}

	private float Abs(float val) {
		return (val < 0.0f) ? -val : val;
	}
}
