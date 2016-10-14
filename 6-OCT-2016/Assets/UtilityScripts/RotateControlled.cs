﻿using UnityEngine;
using System.Collections;

public class RotateControlled : MonoBehaviour 
{
	public Space space;
	public Vector3 rotationPerSecond;

	void Update()
	{
		transform.Rotate(rotationPerSecond * Time.deltaTime, space);
	}

}
	

 