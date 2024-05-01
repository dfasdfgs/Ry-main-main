using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    void Start()
    {
        GameManager.bestScore = GameManager.myTime;

        GetComponent<Text>().text = "Best Score : " + GameManager.bestScore.ToString("F1");
   
    }

    void Update()
    {
        
    }
}
