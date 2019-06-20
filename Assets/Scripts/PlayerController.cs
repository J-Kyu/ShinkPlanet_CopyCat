using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed;

	private Vector3 moveDirection;
	private bool isStart = false;
	[SerializeField] private Text endGame = null;

	void Start()
	{
		endGame.enabled = false;
	}
	void Update()
	{
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate()
	{
		if(isStart)
		{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);
		}
		else
		{
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(new Vector3(0,0,1))*50*Time.deltaTime);
		}
	}

	 void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "BlackAsh")
        {
           endMovement();
		   endGame.enabled = true;
        }
    }


      public void startMovement()
    {
        isStart = true;
    }

    public void endMovement()
    {
        isStart = false;
    }
}
