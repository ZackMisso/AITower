using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour
{
	public float speed;
	public GameObject player; //set this to the player

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate()
	{
		Vector3 difference = player.transform.position - transform.position;
		difference.Normalize ();
		difference.y = 0;
		Debug.Log (difference * speed);
		transform.position = transform.position + (difference * speed);
	}
}

