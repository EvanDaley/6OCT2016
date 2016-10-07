using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{
	private Vector3 startPosition;
	private Rigidbody rbody;
	public float moveForce;

	void Start()
	{
		startPosition = transform.position;
		rbody = GetComponent < Rigidbody>();
	}

	void Update () {
		float x = Input.acceleration.y;
		float y = -Input.acceleration.x;
		rbody.AddForce(new Vector3 (x, 0, y) * moveForce);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			gameObject.transform.position = startPosition;
		}
	}
}
