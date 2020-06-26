using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip SFXCoin; //재생할 소리들 목록
    public AudioClip SFXPacmanDie;
    public AudioClip SFXGhostDie;
    public AudioClip SFXGhostReturn;
    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담는다
    public static SFXManager instance; //single tone
    void Awake()
    { 
        if (SFXManager.instance == null) //instance가 null인지 체크
        {
            SFXManager.instance = this; //싱글톤
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); 
    }

    public void PlaySFXCOin()
    {
        myAudio.PlayOneShot(SFXCoin); 
    }
    public void PlaySFXPacmanDie()
    {
        myAudio.PlayOneShot(SFXPacmanDie);
    }
    public void PlaySFXGhostDie()
    {
        myAudio.PlayOneShot(SFXGhostDie);
    }
    public void PlaySFXGhostReturn()
    {
        myAudio.PlayOneShot(SFXGhostReturn);
    }
    void Update()
    {

    }
}
