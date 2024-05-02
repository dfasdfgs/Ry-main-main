using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Best Time : " + GameManager.minTime.ToString("F1");
    }
}
