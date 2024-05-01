using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioClip[] arrAudio;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30;

    public bool IsGameDone {  
        get
        {
            if (isGameClear || isGameOver)
                return true;
            else
                return false;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        isGameOver = true;
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;
            AudioClip audio = arrAudio[1];
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                isGameClear = true;
            }

        }
        else
        {
            score--;

            AudioClip audio = arrAudio[0];
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        Debug.Log("Game Restart!................");
        SceneManager.LoadScene(0);
    }
}
