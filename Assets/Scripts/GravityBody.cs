using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
	public GameObject attractor;
	private Transform myTransform;

	void Start(){

		myTransform = this.GetComponent<Transform>();
		attractor =  GameObject.Find("Ground");

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
			attractor.GetComponent<GravityAttractor>().Attract(myTransform);
		}
	}
}
