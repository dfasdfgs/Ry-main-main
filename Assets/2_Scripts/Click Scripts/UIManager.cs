using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    [SerializeField] private Image timerImg;
    [SerializeField] private TextMeshProUGUI timerTmp;

    private void Awake()
    {
        Instance = this;    
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore} / {maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;
    }

    public void OnTimerChange(float currentTimer, float maxTimer)
    {
        timerTmp.text = $"{currentTimer:N1} / {maxTimer:N1}";
        timerImg.fillAmount = (float)currentTimer / maxTimer;
    }
}
