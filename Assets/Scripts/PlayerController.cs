using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private float moveSpeed = 40;
	private float rotateSpeed = 100;
	private Vector3 moveDirection;
	private Vector3 rotationDirection;
	[SerializeField] private State state = null;

	private bool isInvincibleState = true;
	

	void Start(){
		isInvincibleState = true;
	}
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
		switch(state.curState){
			case State.Mode.Playing:{
				// GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);
				GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(new Vector3(0,0,1))*moveSpeed*Time.deltaTime);
				break;
			}
			case State.Mode.Ready:{
				// GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(new Vector3(0,0,1))*10*Time.deltaTime);
				break;
			}
			case State.Mode.Menu:{
				GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(new Vector3(0,0,1))*50*Time.deltaTime);
				break;
			}
		}
	}

	 void OnCollisionEnter(Collision col)
    {
		if(isInvincibleState ==  true){
			return ;
		}

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

	public void resetPlayer(float defaultSpeed, float defaultScale)
	{
		moveSpeed = defaultSpeed;
		transform.localScale = new Vector3 (defaultScale,defaultScale,defaultScale);	
		isInvincibleState = true;
	}
	public void venerableState(){
		isInvincibleState = false;
	}

	public float GetSpeed(){
		return moveSpeed;
	}
	public float GetScale(){
		return this.transform.localScale.x;
	}
}
