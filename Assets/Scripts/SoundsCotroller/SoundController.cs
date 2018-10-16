using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    private static SoundController _instance;
    public static SoundController instance {
        get {
            if(_instance == null) {
                _instance = new SoundController ();
                DontDestroyOnLoad (_instance.gameObject);
            }

            return _instance;
        }
    }
    //public GameController gameController;

    public AudioClip S_Background, S_Ball, S_Click, S_Whistle;
    public AudioSource audio;

    public bool isMusic = true;
    public bool isSound = true;
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }

        //audio = GetComponent<AudioSource> ();
        audio.rolloffMode = AudioRolloffMode.Linear;
        audio.volume = 1;
        PlaySoundBackground();
    }
    // Update is called once per frame
    void Update () {
    }
    public void PlaySoundBackground () {
        audio.Stop ();
        if (isMusic)
        {
            audio.loop = true;
            audio.clip = S_Background;
            audio.volume = 0.5f;
            audio.Play();
        }
    }
    public void pauseSound () {
        audio.volume=0 ;
    }
    public void unpauseSound () {
        audio.volume=1 ;
    }

    void PlaySound (AudioClip audioClip) {
        if(isSound) {
            //Debug.Log (audioClip);
            audio.PlayOneShot (audioClip);
        }
    }
    public void ClickSound()
    {
        PlaySound(S_Click);
    }
    public void BallSound()
    {
        PlaySound(S_Ball);
    }
    public void Scored()
    {
        PlaySound(S_Whistle);
    }



}
