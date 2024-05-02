using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCver : MonoBehaviour
{

    [SerializeField] public GameObject gameClear;
    [SerializeField] public GameObject Over;   
    void Start()
    {

        if(GameManager.Instance.IsGameOver())
        {
            Over.SetActive(true);
                
        };
        if (GameManager.Instance.IsGameClear())
        {
            gameClear.SetActive(true);

        };
    }

    void Update()
    {
        
    }
}
