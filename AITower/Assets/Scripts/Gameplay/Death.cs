﻿using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public int deathCount = 0;
    public Vector3 startPosition = new Vector3(0, 1, -5);
    private GUIStyle style = new GUIStyle();

    void Start ()
    {
        style.alignment = TextAnchor.MiddleCenter;
    }

	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "death")
        {
            Die();
        }
    }

    void Die()
    {
        deathCount++;
        transform.position = new Vector3(0, 1, -5);
        Debug.Log("Death Count: " + deathCount);
    }

    void OnGUI ()
    {
        string death_string = deathCount.ToString() + " death";
        if (deathCount != 1)
            death_string += "s";
        
        GUI.Box(new Rect(5, Screen.height - 30,80,25), death_string, style);
    }
}