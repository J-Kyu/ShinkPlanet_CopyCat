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
    private float readyAccumulatedTime = 0.0f;
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
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,500*Time.deltaTime);
				break;
			}
			case State.Mode.Ready:{
                //임시방편, 지금 카메라가 smooth하게 playing 모드로 넘어가지 못한다
                    //slerp 함수가 마지막에 감소하면서 범위에 근접하여서 smooth하게 못 넘어간다....그래서 일단 그냥 시간초로 1 초 이상이면 넘긴다
                readyAccumulatedTime += Time.deltaTime;
                if(readyAccumulatedTime > 1.0f){
                    //turn state into palying mdoe
                    readyAccumulatedTime = 0.0f;
                    state.ModeToPlaying();

                }
                Vector3 newPos = 5 * player.transform.position;
                this.transform.position =Vector3.Slerp(this.transform.position,newPos,cameraReadySpeed*Time.deltaTime);

                Vector3 playerUp = (player.transform.position - this.transform.position).normalized;
                Vector3 cameraUp = this.transform.forward;

                //when the game is started, camera adjustment has to be done
                Quaternion targetRotation = Quaternion.FromToRotation(cameraUp,playerUp) * this.transform.rotation;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,targetRotation,cameraReadySpeed*Time.deltaTime);

                if(IsSameLine(this.transform, player.transform) == true){
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
    public bool IsSameLine(Transform onLineVector, Transform isLineVector){

        float t = isLineVector.position.x/onLineVector.position.x;
        if(Mathf.Abs(onLineVector.position.y * t - isLineVector.position.y) < Eps && Mathf.Abs(onLineVector.position.z * t - isLineVector.position.z) < Eps)
        {
            return true;
        }
		
		return false;
	}
}
