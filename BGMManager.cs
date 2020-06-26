using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip IdleBGM; //재생할 소리들.
    public AudioClip FleeBGM;
    public AudioClip VictoryBGM;
    public AudioClip DefeatBGM;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담기
    public static BGMManager instance; //single tone
    void Awake()
    {
        if (BGMManager.instance == null) //instance가 비어있는지 체크.
        {
            BGMManager.instance = this; //싱글 톤 실현
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
        PlayIdleBGM();
    }

    public void PlayIdleBGM()
    {
        myAudio.loop = true;
        myAudio.clip = IdleBGM;
        myAudio.Play();
    }
    public void PlayFleeBGM()
    {
        myAudio.loop = false;
        myAudio.clip = FleeBGM;
        myAudio.Play();
    }
    public void PlayVictoryBGM()
    {
        myAudio.loop = true;
        myAudio.clip = VictoryBGM;
        myAudio.Play();
    }
    public void PlayDefeatBGM()
    {
        myAudio.loop = true;
        myAudio.clip = DefeatBGM;
        myAudio.Play();
    }
    void Update()
    {

    }
}
