using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject blackAsh = null;
    [SerializeField] private GameObject ground = null;

    void Start()
    {
        ground = GameObject.Find("Ground");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
           GameObject afterEffect = Instantiate(blackAsh,this.transform.position,Quaternion.identity) as GameObject;

            Vector3 gravityUp = (afterEffect.transform.position - ground.transform.position).normalized;
		    Vector3 localUp = afterEffect.transform.up;

          //adjusting rotation
		    Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * afterEffect.transform.rotation;
		    afterEffect.transform.rotation = targetRotation;

            Destroy(this.gameObject);
        }
    }
}
