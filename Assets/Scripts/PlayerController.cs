using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	private Vector3 moveDirection;
	[SerializeField] private State state = null;

	void Update()
	{
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
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
    }
}
