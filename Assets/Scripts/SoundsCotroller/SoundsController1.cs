using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController1 : MonoBehaviour {
    private static SoundsController1 _Instance;
    public static SoundsController1 Instance {
        get
         {
            if(_Instance==null)
            {
                _Instance = new SoundsController1 ();
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
         }
    }
    public AudioClip S_Background, S_Ball, S_Click,S_Whistle;
    public AudioSource _Audio;
    public bool isMusic = true;
    public bool isSound = true;
    
	// Use this for initialization
	void Start () {
        if(_Instance=null)
        {
            _Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this!=_Instance)
            {
                Destroy(this.gameObject);
            }
        }
        _Audio.rolloffMode = AudioRolloffMode.Linear;
        _Audio.volume = 1;
        PlaySoundBackGround();
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySoundBackGround()
    {
        _Audio.Stop();
        if(isMusic)
        {
            _Audio.loop = true;
            _Audio.clip = S_Background;
            _Audio.volume = 1;
            _Audio.Play();
        }
        
    }
    public void PlaySound(AudioClip audioClip)
    {
        if(isSound)
        {
            _Audio.PlayOneShot(audioClip);
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
