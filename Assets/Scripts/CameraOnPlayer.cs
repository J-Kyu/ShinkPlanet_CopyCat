using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    [SerializeField] private State state = null;

    private Vector3 _cameraOffset ;
    private float cameraReadySpeed = 8.0f;
    private const float Eps=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Screen.fullScreen = false;
        // Screen.SetResolution (1080, 768, true);
        _cameraOffset= new Vector3 (0, 120, 0);
        this.transform.position = _cameraOffset;
    }

    // Update is called once per frame
    void Update()
    {

        switch(state.curState){
			case State.Mode.Playing:{
			    Vector3 newPos = 5 * player.transform.position;
                this.transform.position =Vector3.Slerp(this.transform.position,newPos,500f*Time.deltaTime);

                Vector3 playerUp = (player.transform.position - this.transform.position).normalized;
                Vector3 cameraUp = this.transform.forward;

                Quaternion targetRotation = Quaternion.FromToRotation(cameraUp,playerUp) * this.transform.rotation;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,500f*Time.deltaTime);
				break;
			}
			case State.Mode.Ready:{
                Vector3 newPos = 5 * player.transform.position;
                this.transform.position =Vector3.Slerp(this.transform.position,newPos,cameraReadySpeed*Time.deltaTime);

                Vector3 playerUp = (player.transform.position - this.transform.position).normalized;
                Vector3 cameraUp = this.transform.forward;

                //when the game is started, camera adjustment has to be done
                Quaternion targetRotation = Quaternion.FromToRotation(cameraUp,playerUp) * this.transform.rotation;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,cameraReadySpeed*Time.deltaTime);

                if(IsIdneticalAngle(this.transform, player.transform) == true){
                    state.ModeToPlaying();
                }
				
				break;
			}
			case State.Mode.Menu:{
			    Quaternion targetRotation = Quaternion.Euler(90,0,0);

                this.transform.position =Vector3.Slerp(transform.position,new Vector3(0,120,0),Time.deltaTime);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,Time.deltaTime);
				break;
			}
		}
    }
    public bool IsIdneticalAngle(Transform onLineVector, Transform isLineVector){

        float t = isLineVector.position.x/onLineVector.position.x;
        if(Mathf.Abs(onLineVector.position.y * t - isLineVector.position.y) < Eps && Mathf.Abs(onLineVector.position.z * t - isLineVector.position.z) < Eps)
        {
            return true;
        }
		
		return false;
	}
}
