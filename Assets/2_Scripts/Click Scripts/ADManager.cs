using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADManager : MonoBehaviour
{
    public AudioClip[] arrAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // 난수 배열에 등록된 음원중에 임의로 선택
        int sel = Random.Range(0, arrAudio.Length);
        AudioClip audio = arrAudio[sel];

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
    }
}
