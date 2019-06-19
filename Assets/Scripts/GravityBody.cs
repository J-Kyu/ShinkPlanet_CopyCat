using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
	public GravityAttractor attractor;
	private Transform myTransform;

	void Start(){

		myTransform = this.GetComponent<Transform>();

		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

	}
	void FixedUpdate()
	{
		if(myTransform == null){
			Debug.Log("myTransform is null");
			return;
		}

		if(attractor)
		{
			attractor.Attract(myTransform);
		}
	}
}
