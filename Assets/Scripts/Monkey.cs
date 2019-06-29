using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    private float stayingTime = 0.0f;
    
    void Update(){

        stayingTime += Time.deltaTime;

        if(stayingTime > 7f){
            Destroy(this.gameObject);
        }
        
    }
     void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
		  Destroy(this.gameObject);
        }

    }
}
