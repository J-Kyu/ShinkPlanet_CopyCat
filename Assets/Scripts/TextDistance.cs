using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextDistance : MonoBehaviour
{
    [SerializeField] private Text distanceText;
    [SerializeField] private Ground ground;

    void Update() 
    {
        string distanceString = string.Format("Distance: {0:F2}",ground.GetRadius());
        distanceText.text = distanceString;
    }
}
