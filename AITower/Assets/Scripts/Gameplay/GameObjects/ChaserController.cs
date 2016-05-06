using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour
{
	public float speed;
	public GameObject player; //set this to the player
	public Vector3 startPosition;
	public float tetherDistance;

	public Material lineMaterial;

	// Use this for initialization
	void Start ()
	{
		transform.position = startPosition;
		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		Vector3 removeY = startPosition;
		removeY.y = 0;
		lineRenderer.SetPosition (0, removeY);
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

