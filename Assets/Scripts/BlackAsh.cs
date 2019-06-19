using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAsh : MonoBehaviour
{
    private float resetTime = 1.0f;
 
    // Update is called once per frame
    void Update()
    {
        resetTime-= Time.deltaTime;

        if(resetTime < 0)
        {
            resetTime = 0;
            Destroy(this.gameObject);
        }

    }
}
