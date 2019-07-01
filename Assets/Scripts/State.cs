using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game manager
public class State : MonoBehaviour
{
    public enum Mode {Menu,Ready,Playing,Pause,EndGame};
    public Mode curState = Mode.Menu;
    
    [SerializeField] private Ground ground = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private GameObject endGameGO = null;
    [SerializeField] private GameObject waitGO = null;
    [SerializeField] private CameraOnPlayer cameraOnPlayer =null;
    void Start()
    {
        curState = Mode.Menu;
    }

    public void ModeToWait()
    {
        curState = Mode.Menu;
        
        waitGO.SetActive(true);
        endGameGO.SetActive(false);
    }

    public void ModeToPlaying()
    {
        playerController.venerableState();
        curState = Mode.Playing;
    }

    public void ModeToPause()
    {
        curState = Mode.Pause;
    }
    public void ModeToReady()
    {
        waitGO.SetActive(false);
        curState = Mode.Ready;
    }

    public void ModeToEndGame()
    {
        playerController.resetPlayer(40.0f,5.0f);
        endGameGO.SetActive(true);
        ground.DeleteExistingEnemy();
        ground.DeleteExistingItem();
        curState = Mode.EndGame;
    }
   
}
