using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public int deathCount = 0;
    public Vector3 startPosition = new Vector3(0, 1, -5);

    void Start ()
    {

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
}
