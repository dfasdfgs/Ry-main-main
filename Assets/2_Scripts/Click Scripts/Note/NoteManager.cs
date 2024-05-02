using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noetGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F,
        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;
    [SerializeField] private Animator mouseAnim;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodeArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        if (wholeKeyCodeArr.Length == noteGroupList.Count)
            return;

        KeyCode keycode = wholeKeyCodeArr[noteGroupList.Count];
        CreateNoteGroup(keycode);
    }

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noetGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randId = Random.Range(0, 2);
        bool isApple = randId == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                //mouseAnim.SetTrigger("dance");
                mouseAnim.CrossFade("RAT_DFS", 0, 0, 0);
                Invoke("SetIdleAnim", 1f);
                //Debug.Log("RAT_DFS call");
                break;      
            }
        }
    }

    public void SetIdleAnim()
    {
        mouseAnim.CrossFade("RAT_Idel", 0, 0);
    }
}
