using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float shrinkSpeed = 1;
    private float radius = 100;
    private float _radiusOffset = 100;

    [SerializeField] private State state = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private GameObject monkey = null;
    [SerializeField] private GameObject fuel = null;
    [SerializeField] private Transform itemParent = null;
    [SerializeField] private Transform enemyParent = null;
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
        switch(state.curState){

            case State.Mode.Playing:{
                resetTime_e += Time.deltaTime;
                resetTime_i += Time.deltaTime;
                radius -= Time.deltaTime*shrinkSpeed;
                transform.localScale = new Vector3(radius,radius,radius);
            
                //enemy
                if(resetTime_e-0.3f>0){
                    InstantiateEnemy();
                    resetTime_e = 0f;
                }

                //monkey and monmonkey
                if(resetTime_i-5f>0)
                {
                    InstantiateItem();
                    InstantiateItem();
                    resetTime_i = 0f;
                }

                break;
            }
            case State.Mode.Menu:{
                radius = _radiusOffset;
                transform.localScale = Vector3.Slerp(transform.localScale,new Vector3 (_radiusOffset,_radiusOffset,_radiusOffset),Time.deltaTime);

                break;
            }
            default: break;

        }
    
    }

    void InstantiateEnemy()
    {
        Vector3 spawnPos = Random.onUnitSphere *(radius+30);
        GameObject spawnEnemy = Instantiate(enemy,spawnPos,Quaternion.identity,enemyParent) as GameObject;
    }

    void InstantiateItem()
    {
        Vector3 spawnPos_k = Random.onUnitSphere *(radius);
        Vector3 spawnPos_m = Random.onUnitSphere *(radius);



        GameObject spawnItem_m = Instantiate(monkey,spawnPos_k,Quaternion.identity,itemParent) as GameObject;
        GameObject spawnItem_k = Instantiate(fuel,spawnPos_m,Quaternion.identity, itemParent) as GameObject;
    }

    public void DeleteExistingItem(){

        foreach(Transform item in itemParent){
            Destroy(item.GetComponent<GameObject>());
        }
    
    }

     public void DeleteExistingEnemy(){

      foreach(Transform enemy in enemyParent){
          Destroy(enemy.GetComponent<GameObject>());
      }
    }

    public float GetRadius()
    {
        return this.transform.localScale.x;
    }
}
