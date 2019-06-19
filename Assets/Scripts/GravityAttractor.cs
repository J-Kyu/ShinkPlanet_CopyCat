using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
   
	public float gravity = -12;

	public void Attract(Transform body)
	{
		
		//green axis of transform in world position
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.up;

		//applying gravity
		body.GetComponent<Rigidbody>().AddForce(gravityUp*gravity);

		//adjusting rotation
		Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation, targetRotation,500f*Time.deltaTime);

	}
}
