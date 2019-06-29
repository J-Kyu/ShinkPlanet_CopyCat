using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextDistance : MonoBehaviour
{
    [SerializeField] private Text distanceText = null;
    [SerializeField] private Text speedeText = null;
    [SerializeField] private Text scaleText = null;
    [SerializeField] private Ground ground = null;
    [SerializeField] private PlayerController player = null;


    void Update() 
    {
        string speedString = string.Format("Max Speed: {0:F}",player.GetSpeed());
        speedeText.text = speedString;

        string scaleString = string.Format("Scale: {0:F}",player.GetScale());
        scaleText.text = scaleString;

        string distanceString = string.Format("Radius: {0:F2}",ground.GetRadius());
        distanceText.text = distanceString;
    }
}
