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

    void Start()
    {
        curState = Mode.Wait;
    }

    public void ModeToWait()
    {
        ground.resetRadius();
        playerController.resetPlayer(40.0f,5.0f);

        curState = Mode.Wait;
        waitGO.SetActive(true);
        endGameGO.SetActive(false);
    }

    public void ModeToPlaying()
    {
        waitGO.SetActive(false);
        curState = Mode.Playing;
    }

    public void ModeToPause()
    {
        curState = Mode.Pause;
    }

    public void ModeToEndGame()
    {
        endGameGO.SetActive(true);
        curState = Mode.EndGame;
    }
}
