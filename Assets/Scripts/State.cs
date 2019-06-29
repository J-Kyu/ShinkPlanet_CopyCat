using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game manager
public class State : MonoBehaviour
{
    public enum Mode {Wait,Playing,Pause,EndGame};
    public Mode curState = Mode.Wait;
    
    [SerializeField] private Ground ground = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private GameObject endGameGO = null;
    [SerializeField] private GameObject waitGO = null;
    [SerializeField] private CameraOnPlayer cameraOnPlayer =null;
    void Start()
    {
        curState = Mode.Wait;
    }

    public void ModeToWait()
    {
        curState = Mode.Wait;
        
        waitGO.SetActive(true);
        endGameGO.SetActive(false);
    }

    public void ModeToPlaying()
    {
        playerController.venerableState();
        waitGO.SetActive(false);
        cameraOnPlayer.MovingCamera();
        curState = Mode.Playing;
    }

    public void ModeToPause()
    {
        curState = Mode.Pause;
    }

    public void ModeToEndGame()
    {
        playerController.resetPlayer(40.0f,5.0f);
        endGameGO.SetActive(true);
        ground.DeleteExistingEnemy();
        ground.DeleteExistingItem();
        cameraOnPlayer.ResetCameraPosition();
        curState = Mode.EndGame;
    }
}
