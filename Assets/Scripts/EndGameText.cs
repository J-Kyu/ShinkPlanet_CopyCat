using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameText : MonoBehaviour
{
    [SerializeField] private Text finalScore = null;
    [SerializeField] private Ground ground = null;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        string finalString = string.Format("End Game\nFinal Score: {0:F}",ground.GetRadius());
        finalScore.text = finalString;
    }
}
