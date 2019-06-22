using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 10;
	public float rotateSpeed = 30;
	private Vector3 moveDirection;
	private Vector3 rotationDirection;
	[SerializeField] private State state = null;
	


	void Update()
	{
		moveDirection = new Vector3(0,0,Input.GetAxisRaw("Vertical")).normalized;
		if(Input.GetAxisRaw("Horizontal") != 0)
		{
            transform.Rotate(new Vector3(0,(Input.GetAxisRaw("Horizontal") ),0)*rotateSpeed*Time.deltaTime);
		}
	}

	void FixedUpdate()
	{
		if(state.curState == State.Mode.Playing)
		{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);
		}
		else if(state.curState == State.Mode.Wait)
		{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(new Vector3(0,0,1))*50*Time.deltaTime);
		}
	}

	 void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "BlackAsh")
        {
		  state.ModeToEndGame();
        }
		else if(col.gameObject.tag == "Fuel")
		{
			moveSpeed +=5;
		}
		else if(col.gameObject.tag == "Key")
		{
			transform.localScale = transform.localScale *0.8f;
		}
    }
}
