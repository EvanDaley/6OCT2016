using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 startPos;
	private Rigidbody rbody;
	public float moveForce;

	private float stabilityModifierDuration = 4f;
	private float stabilityModifierCooldown = 0;
	private bool stabilityModifierActive = false;

	private float startingDrag;
	public float modifiedDrag = 3;
	public float stabilityModifierSpeedIncrease = 2f;

	void Start () 
	{
		startPos = transform.position;
		rbody = GetComponent<Rigidbody> ();

		startingDrag = rbody.drag;
	}

	public bool StabilityModifierActive
	{
		get { return stabilityModifierActive; }
		set 
		{
			stabilityModifierActive = value;

			if (value == true)
			{
				rbody.drag = modifiedDrag;
			} else
			{
				rbody.drag = startingDrag;
			}
		}
	}

	public float StabilityModifier
	{
		get { 
			if (StabilityModifierActive)
				return stabilityModifierSpeedIncrease;
			else
				return 0;
		}
	}

	public void EngageStabilityModifier()
	{
		stabilityModifierActive = true;
		stabilityModifierCooldown = Time.time + stabilityModifierDuration;
	}
		
	void Update () 
	{
		float x = Input.acceleration.x;
		float y = Input.acceleration.y;

		rbody.AddForce (new Vector3 (x, 0, y) * moveForce * StabilityModifier);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			gameObject.transform.position = startPos;
		}
	}
}
