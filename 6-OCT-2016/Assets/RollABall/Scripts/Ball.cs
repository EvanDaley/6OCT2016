using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 startPos;
	private Rigidbody rbody;
	public float moveForce;

	void Start () 
	{
		startPos = transform.position;
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () 
	{
		float x = Input.acceleration.x;
		float y = Input.acceleration.y;

		rbody.AddForce (new Vector3 (x, 0, y) * moveForce);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			gameObject.transform.position = startPos;
		}
	}
}
