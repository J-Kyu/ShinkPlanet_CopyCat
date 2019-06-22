using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
     void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
		  Destroy(this.gameObject);
        }

    }
}
