using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum Mode {Wait,Playing,Pause,EndGame};
    public Mode curState = Mode.Wait;
    
    [SerializeField] private GameObject endGameGO = null;
    [SerializeField] private GameObject waitGO = null;

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
