using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    void Start()
    {

        GetComponent<Text>().text = "Play Time : " + GameManager.myTime.ToString("F1");
   
    }

    void Update()
    {
        
    }
}
