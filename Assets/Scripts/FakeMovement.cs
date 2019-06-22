using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed = 10;
	void Update()
	{
		moveDirection = new Vector3(0,0,Input.GetAxisRaw("Vertical")).normalized;
		if(Input.GetAxisRaw("Horizontal") != 0)
		{
            transform.Rotate(new Vector3(0,(Input.GetAxisRaw("Horizontal") ),0)*moveSpeed*Time.deltaTime);
		}
		else
		{
			Debug.Log("Debug roation "+ transform.rotation);
		}


	}

	void FixedUpdate()
	{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);

	}
}
