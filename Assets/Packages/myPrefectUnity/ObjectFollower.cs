using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = 0.125f;
	public float lookSpeed = 3;
	public Vector3 offset;

	// Update is called once per frame
	void FixedUpdate ()
	{
		MoveAt ();
	}

	void MoveAt ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}

	public void ChangeTarget (Transform newTarget)
	{
		target = newTarget;
	}

	void Start ()
	{
		offset = transform.position - target.position;
	}
				
}