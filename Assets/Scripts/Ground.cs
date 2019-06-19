using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float shrinkSpeed = 1;
    public float radius = 100;

    [SerializeField] private GameObject enemy = null;
    private float resetTime = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(radius,radius,radius);
    }

    // Update is called once per frame
    void Update()
    {
        resetTime += Time.deltaTime;
        radius -= Time.deltaTime*shrinkSpeed;
        transform.localScale = new Vector3(radius,radius,radius);
        if(resetTime-.5f>0)
        {
            InstantiateEnemy();
            resetTime = 0f;
        }
    
    }

    void InstantiateEnemy()
    {
        Vector3 spawnPos = Random.onUnitSphere *(radius+30);
        GameObject spawnEnemy = Instantiate(enemy,spawnPos,Quaternion.identity) as GameObject;
    }
}
