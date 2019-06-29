using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    public bool isMoving = false;

    private Vector3 _cameraOffset ;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset= new Vector3 (0, 120, 0);
        this.transform.position = _cameraOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            Vector3 newPos = 5 * player.transform.position;
            this.transform.position =Vector3.Slerp(this.transform.position,newPos,500f*Time.deltaTime);

            Vector3 playerUp = (player.transform.position - this.transform.position).normalized;
            Vector3 cameraUp = this.transform.forward;

            Quaternion targetRotation = Quaternion.FromToRotation(cameraUp,playerUp) * this.transform.rotation;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,500f*Time.deltaTime);
        }
        else{
            Quaternion targetRotation = Quaternion.Euler(90,0,0);

            this.transform.position =Vector3.Slerp(transform.position,new Vector3(0,120,0),Time.deltaTime);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,Time.deltaTime);
        }
    }

    public void ResetCameraPosition(){
        isMoving = false;
    }
    public void MovingCamera(){
        isMoving = true;
    }
}
