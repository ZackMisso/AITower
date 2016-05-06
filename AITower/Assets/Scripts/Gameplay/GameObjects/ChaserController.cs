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
		lineRenderer.SetPosition (0, startPosition);
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
		transform.position = transform.position + (difference * speed);
		if ((transform.position - startPosition).magnitude > tetherDistance) {
			Vector3 startDifference = player.transform.position - startPosition;
			startDifference.Normalize ();
			startDifference.y = 0;
			transform.position = startPosition + startDifference * tetherDistance;
		}

		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition (1, transform.position);

	}

	public void Reset ()
	{
		transform.position = startPosition;
	}
}

