using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float shrinkSpeed = 1;
    private float radius = 100;

    [SerializeField] private State state = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private GameObject key = null;
    [SerializeField] private GameObject fuel = null;
    private float resetTime_e = 0f; 
    private float resetTime_i = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(radius,radius,radius);
    }

    // Update is called once per frame
    void Update()
    {
        if(state.curState == State.Mode.Playing)
        {
            resetTime_e += Time.deltaTime;
            resetTime_i += Time.deltaTime;
            radius -= Time.deltaTime*shrinkSpeed;
            transform.localScale = new Vector3(radius,radius,radius);
        
            //enemy
           if(resetTime_e-0.3f>0)
            {
                InstantiateEnemy();
                resetTime_e = 0f;
            }

            //key and monkey
            if(resetTime_i-3f>0)
            {
                InstantiateItem();
                resetTime_i = 0f;
            }


        }
    
    }

    public void resetRadius()
    {
        radius = 100;
        transform.localScale = new Vector3(radius,radius,radius);
    }

    void InstantiateEnemy()
    {
        Vector3 spawnPos = Random.onUnitSphere *(radius+30);
        GameObject spawnEnemy = Instantiate(enemy,spawnPos,Quaternion.identity) as GameObject;
    }

    void InstantiateItem()
    {
        Vector3 spawnPos_k = Random.onUnitSphere *(radius);
        Vector3 spawnPos_m = Random.onUnitSphere *(radius);



        GameObject spawnItem_m = Instantiate(key,spawnPos_k,Quaternion.identity) as GameObject;
        GameObject spawnItem_k = Instantiate(fuel,spawnPos_m,Quaternion.identity) as GameObject;
    }

    public float GetRadius()
    {
        return radius;
    }
}
