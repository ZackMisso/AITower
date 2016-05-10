using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour
{
	public float speed;
	public Vector3 startPosition;
	public float tetherDistance;

	private GameObject player; //set this to the player

	public Material lineMaterial;

	// Use this for initialization
	void Start ()
	{
		startPosition += transform.position;
		startPosition.y = 1;
		//transform.position = startPosition;
		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		Vector3 removeY = transform.position;
		removeY.y = 0;
		lineRenderer.SetPosition (0, removeY);

		//find the player and set the player object to it
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate()
	{
		if ((player.transform.position - startPosition).magnitude > tetherDistance) {
			Vector3 startDifference = startPosition - transform.position;
			startDifference.Normalize ();
			transform.position = transform.position + (startDifference * speed);
		} else {
			Vector3 difference = player.transform.position - transform.position;
			difference.y = 0;
			difference.Normalize ();
			transform.position = transform.position + (difference * speed);
		}

		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition (1, transform.position);

	}

	public void Reset ()
	{
		transform.position = startPosition;
	}
}

